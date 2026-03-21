namespace Calligraphy.Domain.Utility;

public static class Recognizer
{
    /// <summary>
    /// Main entry point. Accepts individual strokes — phantom lines between
    /// stroke endpoints never corrupt feature computation.
    /// </summary>
    public static double CalculateAccuracy(
        IReadOnlyList<IReadOnlyList<StrokePoint>> strokes, string shapeName)
    {
        var allPoints = strokes
            .SelectMany(s => s.Select(p => (p.X, p.Y)))
            .ToList();

        if (allPoints.Count < 8) return 0;

        // Scribble check per stroke — no false intersections from inter-stroke jumps
        int maxCrossings = shapeName == "Heart" ? 35 : 25;
        foreach (var s in strokes)
        {
            var spts = s.Select(p => (p.X, p.Y)).ToList();
            if (!PassesScribbleCheck(spts, maxCrossings)) return 0;
        }

        // ── Point-cloud features (stroke-order independent) ──────────────────
        var hull   = ConvexHull(allPoints);
        var box    = BoundingBox(allPoints);
        double hullArea = Math.Abs(PolygonArea(hull));
        double aspect   = box.h > 0 ? box.w / box.h : 1.0;

        // Convexity: sum of per-stroke polygon areas / hull area.
        // Never connects endpoint of stroke N to start of stroke N+1.
        double convex = ComputeConvexity(strokes, hullArea);

        // Corners: counted per stroke and summed — no phantom direction changes
        int corners = strokes.Sum(s =>
            CountCorners(Smooth(s.Select(p => (p.X, p.Y)).ToList(), 5)));

        return shapeName switch
        {
            "Circle" => ScoreCircle(aspect, convex),
            "Square" => ScoreSquare(aspect, convex, corners),
            "Triangle" => ScoreTriangle(aspect, convex, corners),
            "Diamond" => ScoreDiamond(aspect, convex, corners),
            "Star" => ScoreStar(convex, corners, allPoints),
            "Pentagon" => ScorePentagon(convex, corners),
            "Hexagon" => ScoreHexagon(convex, corners),
            "Oval" => ScoreOval(aspect, convex),
            "Heart" => ScoreHeart(aspect, convex, corners),
            "Cross" => ScoreCross(aspect, convex, corners),
            "Plus" => ScorePlus(aspect, convex, corners),
            "Trapezoid" => ScoreTrapezoid(aspect, convex, corners),
            "HalfMoon" => ScoreHalfMoon(aspect, convex, corners),
            "WaningMoon" => ScoreWaningMoon(aspect, convex, corners),
            _ => 0
        };
    }

    // ── Shape scorers ─────────────────────────────────────────────────────────

    private static double ScoreCircle(double aspect, double convex)
    {
        double sAspect = GaussianScore(aspect, 1.0,  0.35);
        double sConvex = ScaleScore(convex, 0.85, 1.00);
        return 0.40 * sAspect + 0.60 * sConvex;
    }

    private static double ScoreOval(double aspect, double convex)
    {
        // Penalise aspect ratios close to 1.0 (that's a circle).
        // Reward aspect in the range ~1.3–2.2.
        double sAspect = GaussianScore(aspect, 1.6,  0.35);
        double sConvex = ScaleScore(convex, 0.85, 1.00);
        return 0.50 * sAspect + 0.50 * sConvex;
    }

    private static double ScoreSquare(double aspect, double convex, int corners)
    {
        double sAspect  = GaussianScore(aspect, 1.0, 0.25);
        double sConvex  = ScaleScore(convex, 0.82, 1.00);
        double sCorners = GaussianScore(corners, 4.0, 1.5);
        return 0.30 * sAspect + 0.30 * sConvex + 0.40 * sCorners;
    }

    private static double ScoreTriangle(double aspect, double convex, int corners)
    {
        double sAspect  = GaussianScore(aspect, 0.9,  0.35);
        double sConvex  = ScaleScore(convex, 0.75, 1.00);
        double sCorners = GaussianScore(corners, 3.0,  1.2);
        return 0.25 * sAspect + 0.30 * sConvex + 0.45 * sCorners;
    }

    private static double ScoreDiamond(double aspect, double convex, int corners)
    {
        // Diamond is taller than wide — aspect (w/h) < 1
        double sAspect  = GaussianScore(aspect, 0.65, 0.25);
        double sConvex  = ScaleScore(convex, 0.80, 1.00);
        double sCorners = GaussianScore(corners, 4.0,  1.5);
        return 0.30 * sAspect + 0.25 * sConvex + 0.45 * sCorners;
    }

    private static double ScoreStar(double convex, int corners,
        List<(double x, double y)> allPoints)
    {
        if (convex > 0.70) return 0;
        double evenness  = ComputeCornerEvenness(allPoints);
        double sConvex   = GaussianScore(convex, 0.44, 0.15);
        double sCorners  = GaussianScore(corners, 10.0, 3.0);
        double sEvenness = ScaleScore(evenness, 0.15, 0.60);
        return 0.40 * sConvex + 0.35 * sCorners + 0.25 * sEvenness;
    }

    private static double ScorePentagon(double convex, int corners)
    {
        double sConvex  = ScaleScore(convex, 0.82, 1.00);
        double sCorners = GaussianScore(corners, 5.0,  1.5);
        return 0.35 * sConvex + 0.65 * sCorners;
    }

    private static double ScoreHexagon(double convex, int corners)
    {
        double sConvex  = ScaleScore(convex, 0.82, 1.00);
        double sCorners = GaussianScore(corners, 6.0,  1.8);
        return 0.35 * sConvex + 0.65 * sCorners;
    }

    private static double ScoreHeart(double aspect, double convex, int corners)
    {
        double sAspect  = GaussianScore(aspect, 1.0,  0.35);
        double sConvex  = GaussianScore(convex, 0.88, 0.12);
        double sCorners = GaussianScore(corners, 1.0,  1.5);
        return 0.30 * sAspect + 0.45 * sConvex + 0.25 * sCorners;
    }


    private static double ScoreCross(double aspect, double convex, int corners)
    {
        double sAspect  = GaussianScore(aspect, 1.0,  0.30);
        double sConvex  = GaussianScore(convex, 0.50, 0.18);
        double sCorners = GaussianScore(corners, 12.0,  3.0);
        return 0.25 * sAspect + 0.35 * sConvex + 0.40 * sCorners;
    }

    private static double ScorePlus(double aspect, double convex, int corners)
    {
        double sAspect  = GaussianScore(aspect, 1.0,  0.30);
        double sConvex  = GaussianScore(convex, 0.50, 0.18);
        double sCorners = GaussianScore(corners, 12.0,  3.0);
        return 0.25 * sAspect + 0.35 * sConvex + 0.40 * sCorners;
    }

    private static double ScoreTrapezoid(double aspect, double convex, int corners)
    {
        // Distinctly wider than tall — centred at 1.6, away from square (1.0)
        double sAspect  = GaussianScore(aspect, 1.6,  0.35);
        double sConvex  = ScaleScore(convex, 0.80, 1.00);
        double sCorners = GaussianScore(corners, 4.0,  1.5);
        return 0.35 * sAspect + 0.25 * sConvex + 0.40 * sCorners;
    }

    private static double ScoreHalfMoon(double aspect, double convex, int corners)
    {
        double sAspect  = GaussianScore(aspect, 0.55, 0.20);
        double sConvex  = ScaleScore(convex, 0.82, 1.00);
        double sCorners = GaussianScore(corners, 2.0,  1.5);
        return 0.25 * sAspect + 0.45 * sConvex + 0.30 * sCorners;
    }

    private static double ScoreWaningMoon(double aspect, double convex, int corners)
    {
        double sAspect  = GaussianScore(aspect, 1.0,  0.40);
        double sConvex  = GaussianScore(convex, 0.68, 0.18);
        double sCorners = GaussianScore(corners, 2.0,  1.5);
        return 0.25 * sAspect + 0.50 * sConvex + 0.25 * sCorners;
    }
    
    // ── Feature computation ───────────────────────────────────────────────────

    /// <summary>
    /// Convexity = sum of per-stroke polygon areas / convex hull area.
    /// Summing per-stroke prevents phantom edges from corrupting the area.
    /// </summary>
    private static double ComputeConvexity(
        IReadOnlyList<IReadOnlyList<StrokePoint>> strokes, double hullArea)
    {
        if (hullArea < 1e-9) return 0;
        double total = strokes.Sum(s =>
            Math.Abs(PolygonArea(s.Select(p => (p.X, p.Y)).ToList())));
        return Math.Min(1.0, total / hullArea);
    }

    private static double ComputeCornerEvenness(List<(double x, double y)> pts)
    {
        var resampled = Resample(new List<(double, double)>(pts), 200);
        double cx = resampled.Average(p => p.x);
        double cy = resampled.Average(p => p.y);
        const double threshold = Math.PI * 0.22;
        const int window = 8;
        var angles = new List<double>();
        for (int i = window; i < resampled.Count - window; i++)
        {
            double ax = resampled[i].x - resampled[i - window].x;
            double ay = resampled[i].y - resampled[i - window].y;
            double bx = resampled[i + window].x - resampled[i].x;
            double by = resampled[i + window].y - resampled[i].y;
            double lenA = Math.Sqrt(ax * ax + ay * ay);
            double lenB = Math.Sqrt(bx * bx + by * by);
            if (lenA < 1e-9 || lenB < 1e-9) continue;
            double cosA = Math.Max(-1, Math.Min(1, (ax * bx + ay * by) / (lenA * lenB)));
            if (Math.Acos(cosA) > threshold)
            {
                angles.Add(Math.Atan2(resampled[i].y - cy, resampled[i].x - cx));
                i += window;
            }
        }
        if (angles.Count < 3) return 0;
        angles.Sort();
        int n = angles.Count;
        var gaps = new List<double>(n);
        for (int i = 0; i < n; i++)
            gaps.Add((angles[(i + 1) % n] - angles[i] + 2 * Math.PI) % (2 * Math.PI));
        double meanGap = gaps.Average();
        double variance = gaps.Average(g => (g - meanGap) * (g - meanGap));
        double cv = meanGap > 0 ? Math.Sqrt(variance) / meanGap : 1.0;
        return Math.Max(0, 1.0 - cv);
    }

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
            result.Add((sx / (hi - lo + 1), sy / (hi - lo + 1)));
        }
        return result;
    }

    private static int CountCorners(List<(double x, double y)> pts)
    {
        var resampled = Resample(new List<(double, double)>(pts), 200);
        const double threshold = Math.PI * 0.22;
        const int window = 8;
        int corners = 0;
        for (int i = window; i < resampled.Count - window; i++)
        {
            double ax = resampled[i].x - resampled[i - window].x;
            double ay = resampled[i].y - resampled[i - window].y;
            double bx = resampled[i + window].x - resampled[i].x;
            double by = resampled[i + window].y - resampled[i].y;
            double lenA = Math.Sqrt(ax * ax + ay * ay);
            double lenB = Math.Sqrt(bx * bx + by * by);
            if (lenA < 1e-9 || lenB < 1e-9) continue;
            double cosAngle = Math.Max(-1, Math.Min(1, (ax * bx + ay * by) / (lenA * lenB)));
            if (Math.Acos(cosAngle) > threshold) { corners++; i += window; }
        }
        return corners;
    }

    private static bool PassesScribbleCheck(List<(double x, double y)> pts, int maxCrossings)
    {
        if (pts.Count < 4) return false;
        var s = Resample(new List<(double, double)>(pts), Math.Min(80, pts.Count));
        int crossings = 0;
        for (int i = 0; i < s.Count - 1; i++)
            for (int j = i + 2; j < s.Count - 1; j++)
                if (SegmentsIntersect(s[i], s[i + 1], s[j], s[j + 1]))
                    if (++crossings > maxCrossings) return false;
        return true;
    }

    // ── Geometry ──────────────────────────────────────────────────────────────

    private static (double w, double h) BoundingBox(List<(double x, double y)> pts)
    {
        double minX = pts.Min(p => p.x), maxX = pts.Max(p => p.x);
        double minY = pts.Min(p => p.y), maxY = pts.Max(p => p.y);
        return (maxX - minX, maxY - minY);
    }

    private static double PolygonArea(List<(double x, double y)> pts)
    {
        double area = 0;
        int n = pts.Count;
        for (int i = 0; i < n; i++)
        {
            var a = pts[i]; var b = pts[(i + 1) % n];
            area += a.x * b.y - b.x * a.y;
        }
        return area / 2.0;
    }

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
        (double x, double y) o, (double x, double y) a, (double x, double y) b)
        => (a.x - o.x) * (b.y - o.y) - (a.y - o.y) * (b.x - o.x);

    private static List<(double x, double y)> Resample(
        List<(double x, double y)> pts, int n)
    {
        if (pts.Count == 0 || n <= 1) return new List<(double, double)>(pts);
        double totalLen = 0;
        for (int i = 1; i < pts.Count; i++) totalLen += Dist(pts[i - 1], pts[i]);
        if (totalLen < 1e-9) return new List<(double, double)>(pts);
        double interval = totalLen / (n - 1);
        double carry    = 0;
        var result = new List<(double, double)> { pts[0] };
        for (int i = 1; i < pts.Count && result.Count < n; i++)
        {
            double segLen = Dist(pts[i - 1], pts[i]);
            if (carry + segLen >= interval)
            {
                double t = (interval - carry) / segLen;
                var p = Lerp(pts[i - 1], pts[i], t);
                result.Add(p);
                pts.Insert(i, p);
                carry = 0;
            }
            else carry += segLen;
        }
        while (result.Count < n) result.Add(pts[^1]);
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

    private static double GaussianScore(double value, double ideal, double sigma)
    {
        double d = value - ideal;
        return Math.Exp(-(d * d) / (2 * sigma * sigma));
    }

    private static double ScaleScore(double value, double lo, double hi)
    {
        if (value <= lo) return 0;
        if (value >= hi) return 1;
        return (value - lo) / (hi - lo);
    }
}