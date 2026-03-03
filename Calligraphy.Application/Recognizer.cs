using Calligraphy.Domain;

namespace Calligraphy.Application;

public class Recognizer
{
    
    public (bool success, double score) CheckShape(IReadOnlyList<IReadOnlyList<StrokePoint>> strokes, string shapeName)
    
    { 
        if (strokes.Count == 0)
            return (false, 0);
        
        var pts = Flatten(strokes); 
        if (pts.Count < 8) 
            return (false, 0);

        // ── Scribble gate ────────────────────────────────────────────────────
        // Reject before doing any real scoring; spirals and scribbles have
        // far more self-intersections than any legitimate shape.
        
        if (!PassesScribbleCheck(pts)) 
            return (false, 0);

        // ── Extract features ─────────────────────────────────────────────────
        
        var smoothed   = Smooth(pts, 5); 
        var box        = BoundingBox(smoothed); 
        double aspect  = box.h > 0 ? box.w / box.h : 1.0; 
        double convex  = ConvexityRatio(smoothed); 
        double closure = ClosureRatio(smoothed, box); 
        int    corners = CountCorners(smoothed);

        // ── Per-shape scoring ─────────────────────────────────────────────────
        // DEBUG: print features to console so we can tune parameters
        System.Diagnostics.Debug.WriteLine(
            $"[ShapeScore] shape={shapeName} corners={corners} convex={convex:F3} " +
            $"aspect={aspect:F3} closure={closure:F3} " +
            $"evenness={ComputeCornerEvenness(smoothed):F3}");

        double score = shapeName switch
        {
            "Circle"   => ScoreCircle(aspect, convex, closure),
            "Square"   => ScoreSquare(aspect, convex, corners),
            "Triangle" => ScoreTriangle(aspect, convex, corners),
            "Diamond"  => ScoreDiamond(aspect, convex, corners),
            "Star"     => ScoreStar(convex, corners, closure, smoothed),
            "Pentagon" => ScorePentagon(convex, corners),
            "Hexagon"  => ScoreHexagon(convex, corners),
            _          => 0
        };

        double threshold = shapeName switch
        {
            "Circle"   => 0.45,
            "Square"   => 0.42,
            "Triangle" => 0.40,
            "Diamond"  => 0.40,
            "Star"     => 0.38,
            "Pentagon" => 0.40,
            "Hexagon"  => 0.40,
            _          => 0.40
        };

        System.Diagnostics.Debug.WriteLine(
            $"[ShapeScore] finalScore={score:F3} threshold={threshold:F3}");

        return (score >= threshold, score);
    }

    /// <summary>
    /// Returns 0-3 stars based on the score returned by CheckShape.
    /// </summary>
    public static int GetStars(double score)
    {
        if (score >= 0.75) return 3;
        if (score >= 0.55) return 2;
        if (score >= 0.35) return 1;
        return 0;
    }

    // ── Per-shape scorers ─────────────────────────────────────────────────────
    // Each returns a value in [0, 1]. Individual feature scores are blended
    // with weights that reflect how important each feature is for that shape.

    private static double ScoreCircle(double aspect, double convex, double closure)
    {
        // Circle: near-square aspect, very convex, stroke nearly closes on itself.
        double sAspect  = GaussianScore(aspect,  1.0,  0.35);
        double sConvex  = ScaleScore(convex,      0.85, 1.00);
        double sClosure = ScaleScore(closure,     0.60, 1.00);
        return 0.30 * sAspect + 0.35 * sConvex + 0.35 * sClosure;
    }

    private static double ScoreSquare(double aspect, double convex, int corners)
    {
        // Square: near-square aspect, highly convex, ~4 corners.
        double sAspect  = GaussianScore(aspect,  1.0,  0.30);
        double sConvex  = ScaleScore(convex,      0.82, 1.00);
        double sCorners = GaussianScore(corners,  4.0,  1.5);
        return 0.35 * sAspect + 0.30 * sConvex + 0.35 * sCorners;
    }

    private static double ScoreTriangle(double aspect, double convex, int corners)
    {
        // Triangle: taller than wide is common, convex, ~3 corners.
        double sAspect  = GaussianScore(aspect,  0.9,  0.35);
        double sConvex  = ScaleScore(convex,      0.75, 1.00);
        double sCorners = GaussianScore(corners,  3.0,  1.2);
        return 0.25 * sAspect + 0.30 * sConvex + 0.45 * sCorners;
    }

    private static double ScoreDiamond(double aspect, double convex, int corners)
    {
        // Diamond: taller than wide, convex, ~4 corners.
        double sAspect  = GaussianScore(aspect,  0.65, 0.30);
        double sConvex  = ScaleScore(convex,      0.80, 1.00);
        double sCorners = GaussianScore(corners,  4.0,  1.5);
        return 0.35 * sAspect + 0.25 * sConvex + 0.40 * sCorners;
    }

    private static double ScoreStar(double convex, int corners, double closure,
        List<(double x, double y)> pts)
    {
        // Hard gates only for the most reliable discriminators.
        if (closure < 0.55) return 0;
        if (convex  > 0.70) return 0;

        double evenness  = ComputeCornerEvenness(pts);
        double sConvex   = GaussianScore(convex,   0.44, 0.15);
        double sCorners  = GaussianScore(corners,  10.0, 3.0);
        double sEvenness = ScaleScore(evenness,    0.15, 0.60);
        return 0.40 * sConvex + 0.35 * sCorners + 0.25 * sEvenness;
    }

    /// <summary>
    /// Finds the angles of all corners relative to the centroid, then measures
    /// how evenly they are spread around the full 360°. Returns 1.0 for perfectly
    /// even distribution, near 0 for corners all clustered in one region.
    /// </summary>
    private static double ComputeCornerEvenness(List<(double x, double y)> pts)
    {
        var resampled = Resample(new List<(double, double)>(pts), 200);

        double cx = resampled.Average(p => p.x);
        double cy = resampled.Average(p => p.y);

        const double threshold = Math.PI * 0.22;
        const int    window    = 8;

        var angles = new List<double>();

        for (int i = window; i < resampled.Count - window; i++)
        {
            double ax = resampled[i].x          - resampled[i - window].x;
            double ay = resampled[i].y          - resampled[i - window].y;
            double bx = resampled[i + window].x - resampled[i].x;
            double by = resampled[i + window].y - resampled[i].y;

            double lenA = Math.Sqrt(ax * ax + ay * ay);
            double lenB = Math.Sqrt(bx * bx + by * by);
            if (lenA < 1e-9 || lenB < 1e-9) continue;

            double cosA = Math.Max(-1, Math.Min(1, (ax * bx + ay * by) / (lenA * lenB)));
            if (Math.Acos(cosA) > threshold)
            {
                // Record the angle of this corner relative to the centroid
                double angle = Math.Atan2(resampled[i].y - cy, resampled[i].x - cx);
                angles.Add(angle);
                i += window;
            }
        }

        if (angles.Count < 3) return 0;

        // Sort angles and measure the gaps between consecutive corners.
        // For a perfect star the gaps are all equal (~36° for 10 corners).
        // For clustered wiggles the gaps are very uneven.
        angles.Sort();
        int n = angles.Count;
        var gaps = new List<double>(n);
        for (int i = 0; i < n; i++)
        {
            double gap = (angles[(i + 1) % n] - angles[i] + 2 * Math.PI) % (2 * Math.PI);
            gaps.Add(gap);
        }

        double meanGap   = gaps.Average();
        double variance  = gaps.Average(g => (g - meanGap) * (g - meanGap));
        double stdDev    = Math.Sqrt(variance);
        // Coefficient of variation: 0 = perfectly even, higher = more clustered.
        double cv = meanGap > 0 ? stdDev / meanGap : 1.0;
        // Convert to a 0-1 score where 1 = perfectly even.
        return Math.Max(0, 1.0 - cv);
    }

    private static double ScorePentagon(double convex, int corners)
    {
        // Pentagon: convex, ~5 corners.
        double sConvex  = ScaleScore(convex,      0.82, 1.00);
        double sCorners = GaussianScore(corners,  5.0,  1.5);
        return 0.35 * sConvex + 0.65 * sCorners;
    }

    private static double ScoreHexagon(double convex, int corners)
    {
        // Hexagon: convex, ~6 corners.
        double sConvex  = ScaleScore(convex,      0.82, 1.00);
        double sCorners = GaussianScore(corners,  6.0,  1.8);
        return 0.35 * sConvex + 0.65 * sCorners;
    }

    // ── Feature extraction ────────────────────────────────────────────────────

    /// <summary>
    /// Smooths the point list with a simple box filter to remove pen jitter.
    /// </summary>
    private static List<(double x, double y)> Smooth(
        List<(double x, double y)> pts, int radius)
    {
        var result = new List<(double, double)>(pts.Count);
        for (int i = 0; i < pts.Count; i++)
        {
            int lo = Math.Max(0, i - radius);
            int hi = Math.Min(pts.Count - 1, i + radius);
            double sx = 0, sy = 0;
            for (int j = lo; j <= hi; j++) { sx += pts[j].x; sy += pts[j].y; }
            int count = hi - lo + 1;
            result.Add((sx / count, sy / count));
        }
        return result;
    }

    /// <summary>
    /// Ratio of the drawing's area to its convex hull area.
    /// 1.0 = perfectly convex; lower = more concave (e.g. star ~ 0.4-0.5).
    /// </summary>
    private static double ConvexityRatio(List<(double x, double y)> pts)
    {
        double drawingArea = Math.Abs(PolygonArea(pts));
        var    hull        = ConvexHull(pts);
        double hullArea    = Math.Abs(PolygonArea(hull));
        if (hullArea < 1e-9) return 0;
        return Math.Min(1.0, drawingArea / hullArea);
    }

    /// <summary>
    /// How close the end of the stroke is to the start, relative to the
    /// bounding box diagonal. 1.0 = perfectly closed, 0.0 = far apart.
    /// </summary>
    private static double ClosureRatio(
        List<(double x, double y)> pts,
        (double w, double h) box)
    {
        double diagonal = Math.Sqrt(box.w * box.w + box.h * box.h);
        if (diagonal < 1e-9) return 0;
        double gap = Dist(pts[0], pts[^1]);
        return Math.Max(0, 1.0 - gap / diagonal);
    }


    /// <summary>
    /// Works on the resampled path so corner count is independent of drawing speed.
    /// </summary>
    private static int CountCorners(List<(double x, double y)> pts)
    {
        var resampled = Resample(new List<(double, double)>(pts), 200);

        const double threshold = Math.PI * 0.22; // ~40 degrees
        const int    window    = 8;

        int corners = 0;
        for (int i = window; i < resampled.Count - window; i++)
        {
            double ax = resampled[i].x          - resampled[i - window].x;
            double ay = resampled[i].y          - resampled[i - window].y;
            double bx = resampled[i + window].x - resampled[i].x;
            double by = resampled[i + window].y - resampled[i].y;

            double lenA = Math.Sqrt(ax * ax + ay * ay);
            double lenB = Math.Sqrt(bx * bx + by * by);
            if (lenA < 1e-9 || lenB < 1e-9) continue;

            double cosAngle = Math.Max(-1, Math.Min(1, (ax * bx + ay * by) / (lenA * lenB)));
            if (Math.Acos(cosAngle) > threshold)
            {
                corners++;
                i += window; // skip ahead to avoid counting the same corner twice
            }
        }
        return corners;
    }

    // ── Scribble detection ────────────────────────────────────────────────────

    private static bool PassesScribbleCheck(List<(double x, double y)> pts)
    {
        if (pts.Count < 4) return false;

        var s = Resample(new List<(double, double)>(pts), Math.Min(80, pts.Count));
        int crossings  = 0;
        int maxAllowed = 25;

        for (int i = 0; i < s.Count - 1; i++)
        {
            for (int j = i + 2; j < s.Count - 1; j++)
            {
                if (SegmentsIntersect(s[i], s[i + 1], s[j], s[j + 1]))
                {
                    if (++crossings > maxAllowed)
                        return false;
                }
            }
        }
        return true;
    }

    // ── Scoring helpers ───────────────────────────────────────────────────────

    /// <summary>
    /// Gaussian bell curve centred on ideal. Returns 1.0 when value == ideal.
    /// </summary>
    private static double GaussianScore(double value, double ideal, double sigma)
    {
        double d = value - ideal;
        return Math.Exp(-(d * d) / (2 * sigma * sigma));
    }

    /// <summary>Linear ramp: 0 at or below lo, 1 at or above hi.</summary>
    private static double ScaleScore(double value, double lo, double hi)
    {
        if (value <= lo) return 0;
        if (value >= hi) return 1;
        return (value - lo) / (hi - lo);
    }

    // ── Geometry ──────────────────────────────────────────────────────────────

    private static double PolygonArea(List<(double x, double y)> pts)
    {
        double area = 0;
        int n = pts.Count;
        for (int i = 0; i < n; i++)
        {
            var a = pts[i];
            var b = pts[(i + 1) % n];
            area += a.x * b.y - b.x * a.y;
        }
        return area / 2.0;
    }

    /// <summary>Andrew's monotone chain convex hull. O(n log n).</summary>
    private static List<(double x, double y)> ConvexHull(List<(double x, double y)> pts)
    {
        var sorted = pts.OrderBy(p => p.x).ThenBy(p => p.y).ToList();
        var hull   = new List<(double, double)>();

        foreach (var p in sorted)
        {
            while (hull.Count >= 2 && Cross(hull[^2], hull[^1], p) <= 0)
                hull.RemoveAt(hull.Count - 1);
            hull.Add(p);
        }

        int lower = hull.Count + 1;
        for (int i = sorted.Count - 2; i >= 0; i--)
        {
            var p = sorted[i];
            while (hull.Count >= lower && Cross(hull[^2], hull[^1], p) <= 0)
                hull.RemoveAt(hull.Count - 1);
            hull.Add(p);
        }

        hull.RemoveAt(hull.Count - 1);
        return hull;
    }

    private static bool SegmentsIntersect(
        (double x, double y) a, (double x, double y) b,
        (double x, double y) c, (double x, double y) d)
    {
        double d1 = Cross(c, d, a), d2 = Cross(c, d, b);
        double d3 = Cross(a, b, c), d4 = Cross(a, b, d);
        return ((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) &&
               ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0));
    }

    private static double Cross(
        (double x, double y) o,
        (double x, double y) a,
        (double x, double y) b)
        => (a.x - o.x) * (b.y - o.y) - (a.y - o.y) * (b.x - o.x);

    private static List<(double x, double y)> Resample(
        List<(double x, double y)> pts, int n)
    {
        if (pts.Count == 0 || n <= 1) return new List<(double, double)>(pts);

        double totalLen = 0;
        for (int i = 1; i < pts.Count; i++)
            totalLen += Dist(pts[i - 1], pts[i]);

        if (totalLen < 1e-9) return new List<(double, double)>(pts);

        double interval = totalLen / (n - 1);
        double carry    = 0;
        var result      = new List<(double, double)> { pts[0] };

        for (int i = 1; i < pts.Count && result.Count < n; i++)
        {
            double segLen = Dist(pts[i - 1], pts[i]);
            if (carry + segLen >= interval)
            {
                double t = (interval - carry) / segLen;
                var p    = Lerp(pts[i - 1], pts[i], t);
                result.Add(p);
                pts.Insert(i, p);
                carry = 0;
            }
            else
            {
                carry += segLen;
            }
        }

        while (result.Count < n)
            result.Add(pts[^1]);

        return result;
    }

    private static double Dist((double x, double y) a, (double x, double y) b)
    {
        double dx = a.x - b.x, dy = a.y - b.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    private static (double x, double y) Lerp(
        (double x, double y) a, (double x, double y) b, double t)
        => (a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);

    private static (double w, double h) BoundingBox(List<(double x, double y)> pts)
    {
        double minX = pts.Min(p => p.x), maxX = pts.Max(p => p.x);
        double minY = pts.Min(p => p.y), maxY = pts.Max(p => p.y);
        return (maxX - minX, maxY - minY);
    }

    // ── Conversion helpers ────────────────────────────────────────────────────

    private static List<(double x, double y)> Flatten(
        IReadOnlyList<IReadOnlyList<StrokePoint>> strokes)
    {
        var pts = new List<(double, double)>();
        foreach (var stroke in strokes)
            foreach (var p in stroke)
                pts.Add((p.X, p.Y));
        return pts;
    }
}