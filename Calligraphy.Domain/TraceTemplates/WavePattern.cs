namespace Calligraphy.Domain.TraceTemplates;

public class WavePattern : TraceTemplate
{
    private const double BaselineY = 450;
    private const int LoopCount = 9;
    private const double LoopWidth = 110;
    private const int PointsPerLoop = 100;
    private const double StartX = 100;
    private const double TopY = 500;

    public override TraceShapeStyle ShapeStyle => TraceShapeStyle.SmoothWaves;
    
    public override string Name => "WavePattern";

    public override List<StrokePoint> GetTemplatePoints()
    {
        var points = new List<StrokePoint>();
        double x = StartX;

        for (int i = 0; i < LoopCount; i++)
        {
            // upward arc
            var p0 = new StrokePoint(x, BaselineY);
            var p1 = new StrokePoint(x, BaselineY - 30);
            var p2 = new StrokePoint(x + LoopWidth * 0.2, TopY);
            var p3 = new StrokePoint(x + LoopWidth * 0.5, TopY);

            for (int j = 0; j < PointsPerLoop / 2; j++)
            {
                double t = (double)j / (PointsPerLoop / 2);
                points.Add(EvaluateBezier(p0, p1, p2, p3, t));
            }

            // downward arc
            p0 = new StrokePoint(x + LoopWidth * 0.5, TopY);
            p1 = new StrokePoint(x + LoopWidth * 0.8, TopY);
            p2 = new StrokePoint(x + LoopWidth, BaselineY - 30);
            p3 = new StrokePoint(x + LoopWidth, BaselineY);

            for (int j = 0; j < PointsPerLoop / 2; j++)
            {
                double t = (double)j / (PointsPerLoop / 2);
                points.Add(EvaluateBezier(p0, p1, p2, p3, t));
            }

            x += LoopWidth;
        }

        return points;
    }
}