namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseR : Letter
{
    public override string Name { get; } = "r";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 129.096180;
        double cy = 81.950981;

        AddRelativeBezier(newPoints, ref cx, ref cy, -9.785810, 8.008103, -21.771660, 14.965279, -33.513885, 10.595004, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -8.644358, -3.217289, -14.074001, -9.791091, -22.577778, -9.812666, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -9.242975, -0.023470, -16.611825, 4.730590, -24.694444, 12.270440, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 129.083660;
        cy = 81.789362;

        AddRelativeBezier(newPoints, ref cx, ref cy, -6.18613, 23.839, -10.2087, 48.7978, -15.2949, 73.3524, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.13066, 10.2861, -5.90887, 24.6681, -4.6173, 34.5188, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.49359, 11.3916, 6.97233, 17.9615, 17.7958, 18.8573, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 12.638, 1.04592, 22.1605, -5.85551, 32.0985, -12.7446, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}