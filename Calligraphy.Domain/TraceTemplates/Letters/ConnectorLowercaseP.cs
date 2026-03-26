namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseP : Letter
{
    public ConnectorLowercaseP()
    {
        IsLow = true;
    }

    public override string Name { get; } = "p";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 67.876962;
        double cy = 61.114631;

        AddRelativeBezier(newPoints, ref cx, ref cy, -11.988986, 9.128728, -26.896237, 20.821080, -39.511111, 30.338889, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 67.899068;
        cy = 61.023416;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.33877, 7.4462, -3.51692, 16.5984, -5.2161, 24.9945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.624618, 3.08641, -0.931177, 5.09464, -1.85747, 8.44032, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.7011, 6.14418, -3.11977, 11.5981, -4.5431, 18.3444, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.25268, 34.3764, -15.247, 68.602, -22.3595, 103.011, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 58.322147;
        cy = 104.267030;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.723585, -11.450485, 7.798555, -21.096107, 15.811976, -29.300386, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 11.179970, -11.446244, 34.784277, -20.585996, 47.926707, -7.293138, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 18.8537, 19.0695, -11.9214, 53.8859, -0.56084, 74.312, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.04735, 12.6711, 25.1936, 2.36004, 32.0722, -2.7935, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}