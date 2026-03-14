namespace Calligraphy.Domain.TraceTemplates.Letters;

public abstract class Letter : TraceTemplate
{
    protected void AddRelativeBezier(List<StrokePoint> points, ref double cx, ref double cy, 
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

        cx = p3.X;
        cy = p3.Y;
    }
    
    protected List<StrokePoint> ScaleAndCenter(List<StrokePoint> points, double screenWidth = 1200, double screenHeight = 800, double marginY = 300)
    {
        if (!points.Any()) return points;

        double minX = points.Min(p => p.X);
        double maxX = points.Max(p => p.X);
        double minY = points.Min(p => p.Y);
        double maxY = points.Max(p => p.Y);

        double originalWidth = maxX - minX;
        double originalHeight = maxY - minY;

        double targetHeight = screenHeight - (marginY * 2);
        
        double scale = targetHeight / originalHeight;
        double targetWidth = originalWidth * scale;

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
}