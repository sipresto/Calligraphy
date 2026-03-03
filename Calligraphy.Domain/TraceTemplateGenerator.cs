
namespace Calligraphy.Domain;

//Generates template points for trace patterns so we can use them for drawing and analysis
public static class TraceTemplateGenerator
{
    public static List<StrokePoint> GenerateHopPattern(
        double startX, 
        double baselineY, 
        double topY,
        double loopWidth, 
        int loopCount, 
        int pointsPerLoop = 50)
    {
        var points = new List<StrokePoint>();
        double x = startX;

        for (int i = 0; i < loopCount; i++)
        {
            // upward arc
            var p0 = new StrokePoint(x, baselineY);
            var p1 = new StrokePoint(x, baselineY - 30);
            var p2 = new StrokePoint(x + loopWidth * 0.2, topY);
            var p3 = new StrokePoint(x + loopWidth * 0.5, topY);

            for (int j = 0; j < pointsPerLoop / 2; j++)
            {
                double t = (double)j / (pointsPerLoop / 2);
                points.Add(EvaluateBezier(p0, p1, p2, p3, t));
            }

            // downward arc
            p0 = new StrokePoint(x + loopWidth * 0.5, topY);
            p1 = new StrokePoint(x + loopWidth * 0.8, topY);
            p2 = new StrokePoint(x + loopWidth, baselineY - 30);
            p3 = new StrokePoint(x + loopWidth, baselineY);

            for (int j = 0; j < pointsPerLoop / 2; j++)
            {
                double t = (double)j / (pointsPerLoop / 2);
                points.Add(EvaluateBezier(p0, p1, p2, p3, t));
            }

            x += loopWidth;
        }

        return points;
    }
    
    // For evaluation of the points
    private static StrokePoint EvaluateBezier(StrokePoint p0, StrokePoint p1, StrokePoint p2, StrokePoint p3, double t)
    {
        double u = 1 - t;
        double tt = t * t;
        double uu = u * u;
        double uuu = uu * u;
        double ttt = tt * t;

        double x = uuu * p0.X + 3 * uu * t * p1.X + 3 * u * tt * p2.X + ttt * p3.X;
        double y = uuu * p0.Y + 3 * uu * t * p1.Y + 3 * u * tt * p2.Y + ttt * p3.Y;

        return new StrokePoint(x, y);
    }
}