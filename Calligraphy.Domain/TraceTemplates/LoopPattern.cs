namespace Calligraphy.Domain.TraceTemplates;

public class LoopPattern : TraceTemplate
{
    private const double GroundY = 450;
    private const double LoopTopY = 350;
    private const int LoopCount = 12;
    private const double LoopWidth = 80; 
    private const int PointsPerLoop = 100;
    private const double StartX = 100;

    public override TraceShapeStyle ShapeStyle => TraceShapeStyle.Cursive;
    public override TraceJoinStyle PreferredJoinStyle => TraceJoinStyle.Round;
    public override string Name => "LoopPattern";

    public override List<StrokePoint> GetTemplatePoints()
    {
        var points = new List<StrokePoint>();
        double height = GroundY - LoopTopY;
        
        // We use a parametric equation for a loop
        // x = t - sin(t)
        // y = cos(t)
        for (int i = 0; i < LoopCount; i++)
        {
            double loopOffset = StartX + (i * LoopWidth);

            for (int step = 0; step <= PointsPerLoop; step++)
            {
                // Normalize t from 0 to 2*PI
                double t = (step / (double)PointsPerLoop) * Math.PI * 2;

                // Parametric loop logic
                // We multiply sin(t) by a factor > 1 to ensure it loops back
                double x = loopOffset + (LoopWidth * (step / (double)PointsPerLoop)) - (Math.Sin(t) * 20);
                
                // Vertical movement (cosine creates the up-and-down)
                // Offset by height to keep it between TopY and BaselineY
                double y = LoopTopY + (height / 2) - (Math.Cos(t) * (height / 2));

                points.Add(new StrokePoint(x, y));
            }
        }

        return points;
    }

    public override TraceTemplateMetadata GetMetadata()
    {
        return new TraceTemplateMetadata
        {
            StartX = StartX,
            BaselineY = GroundY,
            CapHeightY = LoopTopY,
            UnitWidth = LoopWidth,
            RepeatCount = LoopCount
        };
    }
}