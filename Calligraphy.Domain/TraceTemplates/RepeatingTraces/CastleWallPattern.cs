namespace Calligraphy.Domain.TraceTemplates.RepeatingTraces;

public class CastleWallPattern : RepeatingTrace
{
    private const double GroundY = 450;
    private const double BattlementY = 400;
    private const int MerlonCount = 9;
    private const double MerlonWidth = 50;
    private const double CrenelWidth = 50;
    private const int PointsPerMerlon = 100;
    private const double WallStartX = 100;

    public override TraceShapeStyle ShapeStyle => TraceShapeStyle.SquareWall;
    public override TraceJoinStyle PreferredJoinStyle => TraceJoinStyle.Sharp;

    public override List<StrokePoint> GetTemplatePoints()
    {
        var points = new List<StrokePoint>();
        double x = WallStartX;
        int ptsPerSegment = PointsPerMerlon / 4;

        double offset = 12; 

        double hoverTop = BattlementY - offset;
        double hoverBottom = GroundY - offset;

        for (int i = 0; i <= MerlonCount; i++)
        {
            AddLinearPoints(points, x - offset, hoverBottom, x - offset, hoverTop, ptsPerSegment);

            AddLinearPoints(points, x - offset, hoverTop, x + MerlonWidth + offset, hoverTop, ptsPerSegment);

            AddLinearPoints(points, x + MerlonWidth + offset, hoverTop, x + MerlonWidth + offset, hoverBottom, ptsPerSegment);

            if (i < MerlonCount)
            {
                double nextX = x + MerlonWidth + CrenelWidth;
                AddLinearPoints(points, x + MerlonWidth + offset, hoverBottom, nextX - offset, hoverBottom, ptsPerSegment);
            }

            x += MerlonWidth + CrenelWidth;
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
}