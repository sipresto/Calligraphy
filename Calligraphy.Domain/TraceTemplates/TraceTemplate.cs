namespace Calligraphy.Domain.TraceTemplates;

public abstract class TraceTemplate
{
    public abstract List<StrokePoint> GetTemplatePoints();
    
    public virtual List<StrokePoint> GetTemplatePoints(double width, double height) 
    {
        return GetTemplatePoints();
    }

    protected static StrokePoint EvaluateBezier(StrokePoint p0, StrokePoint p1, StrokePoint p2, StrokePoint p3,
        double t)
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