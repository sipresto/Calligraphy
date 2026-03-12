namespace Calligraphy.Domain.TraceTemplates.RepeatingTraces;

public class MountainPattern : RepeatingTrace
{
    private const double StartX = 100;
    private const double GroundY = 550;   // Positioned lower on screen
    private const double PeakY = 400;     // The top of the mountain
    private const double UnitWidth = 80;  // Width of one "V"
    private const int RepeatCount = 12;
    private const int PointsPerSlope = 40; // 40 up + 40 down = 80 points per peak

    public override TraceShapeStyle ShapeStyle => TraceShapeStyle.SquareWall; // Uses sharp lines
    public override TraceJoinStyle PreferredJoinStyle => TraceJoinStyle.Sharp;

    public override List<StrokePoint> GetTemplatePoints()
    {
        var points = new List<StrokePoint>();
        double x = StartX;

        for (int i = 0; i < RepeatCount; i++)
        {
            // 1. Climb Up (From Ground to Peak)
            AddLinearPoints(points, x, GroundY, x + (UnitWidth / 2), PeakY, PointsPerSlope);
            
            // 2. Climb Down (From Peak to Ground)
            AddLinearPoints(points, x + (UnitWidth / 2), PeakY, x + UnitWidth, GroundY, PointsPerSlope);

            x += UnitWidth;
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