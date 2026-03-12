namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseA : TraceTemplate
{
    public override string Name => "HopPattern";

    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        // --- PATH 1: The main loop/belly of the 'a' (SVG path3229) ---
        double cx = 155.1756;
        double cy = 104.12781;
        
        AddRelativeBezier(rawPoints, ref cx, ref cy, -0.22447, 3.75727, -0.53594, 6.38143, -0.9735, 10.93611, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, -2.22073, 23.11592, -9.66282, 56.16806, -21.25568, 71.61389, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, -13.85384, 18.45826, -37.681967, 31.93595, -61.731931, 22.19565, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, -19.084694, -7.72935, -22.416688, -29.69462, -18.884857, -48.65399, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, 2.94757, -15.82296, 11.820344, -30.90454, 23.825759, -41.78788, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, 10.956437, -9.93241, 23.109108, -17.10522, 37.745209, -19.619349, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, 10.71373, -1.84037, 25.28811, 1.360149, 34.925, 3.508009, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, 2.77228, 0.61789, 3.34433, 1.37887, 5.96046, 0.89829, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, 2.16819, -0.39829, 3.40334, -2.56284, 3.91732, -3.324066, pointsPerCurve);

        // --- PATH 2: The updated stem and tail (SVG path3233) ---
        cx = 139.43144;
        cy = 175.59396;

        AddRelativeBezier(rawPoints, ref cx, ref cy, -0.1124, 6.27212, 0.33021, 8.48451, 1.02722, 14.80299, pointsPerCurve);
        AddRelativeBezier(rawPoints, ref cx, ref cy, 3.60559, 32.68554, 29.61743, 21.67742, 44.74296, 7.8641, pointsPerCurve);

        // --- AUTO-SCALER AND CENTER LOGIC ---
        return ScaleAndCenter(rawPoints, screenWidth: 1200, screenHeight: 800, marginY: 150);
    }

    private void AddRelativeBezier(List<StrokePoint> points, ref double cx, ref double cy, 
        double dx1, double dy1, double dx2, double dy2, double dx3, double dy3, int count)
    {
        var p0 = new StrokePoint(cx, cy);
        var p1 = new StrokePoint(cx + dx1, cy + dy1);
        var p2 = new StrokePoint(cx + dx2, cy + dy2);
        var p3 = new StrokePoint(cx + dx3, cy + dy3);

        for (int i = 0; i <= count; i++)
        {
            double t = (double)i / count;
            points.Add(EvaluateBezier(p0, p1, p2, p3, t));
        }

        // Update the current position to the end of this curve
        cx = p3.X;
        cy = p3.Y;
    }

    private List<StrokePoint> ScaleAndCenter(List<StrokePoint> points, double screenWidth, double screenHeight, double marginY)
    {
        if (!points.Any()) return points;

        double minX = points.Min(p => p.X);
        double maxX = points.Max(p => p.X);
        double minY = points.Min(p => p.Y);
        double maxY = points.Max(p => p.Y);

        double originalWidth = maxX - minX;
        double originalHeight = maxY - minY;

        // Target height is total screen height minus top and bottom margins (800 - 150 - 150 = 500)
        double targetHeight = screenHeight - (marginY * 2);
        
        // Scale to fit the target height while maintaining aspect ratio
        double scale = targetHeight / originalHeight;
        double targetWidth = originalWidth * scale;

        // Calculate offsets to center horizontally and apply the top margin
        double offsetX = (screenWidth - targetWidth) / 2;
        double offsetY = marginY;

        var scaledPoints = new List<StrokePoint>();
        foreach (var p in points)
        {
            double newX = ((p.X - minX) * scale) + offsetX;
            double newY = ((p.Y - minY) * scale) + offsetY;
            scaledPoints.Add(new StrokePoint(newX, newY));
        }

        return scaledPoints;
    }

    public override TraceTemplateMetadata GetMetadata()
    {
        return new TraceTemplateMetadata(); 
    }
}