namespace Calligraphy.Domain.TraceTemplates;

public class CastleWallPattern : TraceTemplate
{
    private const double BaselineY = 450;
    private const int LoopCount = 8;
    private const double LoopWidth = 100;
    private const int PointsPerLoop = 100;
    private const double StartX = 100;
    private const double TopY = 350;

    public override TraceShapeStyle ShapeStyle => TraceShapeStyle.SquareWall;
    public override TraceJoinStyle PreferredJoinStyle => TraceJoinStyle.Sharp;

    public override string Name => "CastleWallPattern";

    public override List<StrokePoint> GetTemplatePoints()
    {
        var points = new List<StrokePoint>();
        double x = StartX;
        int ptsPerSegment = PointsPerLoop / 4;

        for (int i = 0; i < LoopCount; i++)
        {
            // 1. Vertical Up
            AddLinearPoints(points, x, BaselineY, x, TopY, ptsPerSegment);
            
            // 2. Horizontal Top
            AddLinearPoints(points, x, TopY, x + LoopWidth * 0.5, TopY, ptsPerSegment);
            
            // 3. Vertical Down
            AddLinearPoints(points, x + LoopWidth * 0.5, TopY, x + LoopWidth * 0.5, BaselineY, ptsPerSegment);
            
            // 4. Horizontal Bottom (Connect to next)
            AddLinearPoints(points, x + LoopWidth * 0.5, BaselineY, x + LoopWidth, BaselineY, ptsPerSegment);

            x += LoopWidth;
        }

        return points;
    }

    private void AddLinearPoints(List<StrokePoint> points, double x1, double y1, double x2, double y2, int count)
    {
        for (int i = 0; i < count; i++)
        {
            double t = (double)i / count;
            points.Add(new StrokePoint(
                x1 + (x2 - x1) * t,
                y1 + (y2 - y1) * t
            ));
        }
    }

    public override TraceTemplateMetadata GetMetadata()
    {
        return new TraceTemplateMetadata
        {
            StartX = StartX,
            BaselineY = BaselineY,
            TopY = TopY,
            LoopWidth = LoopWidth,
            LoopCount = LoopCount
        };
    }
}