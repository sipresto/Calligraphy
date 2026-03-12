namespace Calligraphy.Domain.TraceTemplates;

public class LoopPattern : TraceTemplate
{
    private const double GroundY = 450; 
    private const double LoopTopY = 350;
    private const int RepeatCount = 12;
    private const double UnitWidth = 80; 
    private const int PointsPerSegment = 50; //100 points per loop
    private const double StartX = 100;

    public override TraceShapeStyle ShapeStyle => TraceShapeStyle.Cursive;
    public override TraceJoinStyle PreferredJoinStyle => TraceJoinStyle.Round;
    public override string Name => "LoopPattern";

    public override List<StrokePoint> GetTemplatePoints()
    {
        var points = new List<StrokePoint>();
        double x = StartX;

        for (int i = 0; i < RepeatCount; i++)
        {
            // --- PART 1: THE UPWARD SWEEP ---
            // p0: Start on baseline
            // p1: Pulls the line far to the right
            // p2: Angles the top to curve back
            // p3: The peak of the loop
            var p0 = new StrokePoint(x, GroundY);
            var p1 = new StrokePoint(x + UnitWidth * 0.9, GroundY);
            var p2 = new StrokePoint(x + UnitWidth * 1.2, LoopTopY); 
            var p3 = new StrokePoint(x + UnitWidth * 0.5, LoopTopY);

            // --- PART 2: THE DOWNWARD CROSS ---
            // q0: Starts at the peak (p3)
            // q1: Pulls to the left to create the "eye" of the loop
            // q2: Pulls toward the baseline
            // q3: Ends at the start of the NEXT loop
            var q0 = p3;
            var q1 = new StrokePoint(x - UnitWidth * 0.1, LoopTopY);
            var q2 = new StrokePoint(x + UnitWidth * 0.2, GroundY);
            var q3 = new StrokePoint(x + UnitWidth,       GroundY);

            // Sample Upward Stroke
            for (int step = 0; step < PointsPerSegment; step++)
            {
                double t = step / (double)PointsPerSegment;
                points.Add(SampleCubicBezier(p0, p1, p2, p3, t));
            }

            // Sample Downward Stroke
            for (int step = 0; step < PointsPerSegment; step++)
            {
                double t = step / (double)PointsPerSegment;
                points.Add(SampleCubicBezier(q0, q1, q2, q3, t));
            }

            x += UnitWidth;
        }

        // Add the very last point
        points.Add(new StrokePoint(x, GroundY));

        return points;
    }

    private static StrokePoint SampleCubicBezier(
        StrokePoint p0, StrokePoint p1, StrokePoint p2, StrokePoint p3,
        double t)
    {
        double u = 1 - t;
        double tt = t * t;
        double uu = u * u;
        double uuu = uu * u;
        double ttt = tt * t;

        double bx = uuu * p0.X + 3 * uu * t * p1.X + 3 * u * tt * p2.X + ttt * p3.X;
        double by = uuu * p0.Y + 3 * uu * t * p1.Y + 3 * u * tt * p2.Y + ttt * p3.Y;
        
        return new StrokePoint(bx, by);
    }
}