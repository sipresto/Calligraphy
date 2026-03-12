namespace Calligraphy.Domain.TraceTemplates.RepeatingTraces;

public class CastleWallPattern : RepeatingTrace
{
    private const double GroundY = 450;
    private const int MerlonCount = 9;
    private const double MerlonWidth = 50;
    private const double CrenelWidth = 50;
    private const int PointsPerMerlon = 100;
    private const double WallStartX = 100;
    private const double BattlementY = 400;

    public override TraceShapeStyle ShapeStyle => TraceShapeStyle.SquareWall;
    public override TraceJoinStyle PreferredJoinStyle => TraceJoinStyle.Sharp;

    public override List<StrokePoint> GetTemplatePoints()
    {
        var points = new List<StrokePoint>();
        double x = WallStartX;
        int ptsPerSegment = PointsPerMerlon / 4;

        for (int i = 0; i < MerlonCount; i++)
        {
            //Rise to battlement
            AddLinearPoints(points, x, GroundY, x, BattlementY, ptsPerSegment);
            //Cross the merlon top
            AddLinearPoints(points, x, BattlementY, x + MerlonWidth, BattlementY, ptsPerSegment);
            //Drop to ground
            AddLinearPoints(points, x + MerlonWidth, BattlementY, x + MerlonWidth, GroundY, ptsPerSegment);
            //Cross the crenel to next merlon
            AddLinearPoints(points, x + MerlonWidth, GroundY, x + MerlonWidth + CrenelWidth, GroundY, ptsPerSegment);

            x += MerlonWidth + CrenelWidth;
        }
        //CLOSE
        AddLinearPoints(points, x, GroundY, x, BattlementY, ptsPerSegment);
        AddLinearPoints(points, x, BattlementY, x + MerlonWidth, BattlementY, ptsPerSegment);
        AddLinearPoints(points, x + MerlonWidth, BattlementY, x + MerlonWidth, GroundY, ptsPerSegment);

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