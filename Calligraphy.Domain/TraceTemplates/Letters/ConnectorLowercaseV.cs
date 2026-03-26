namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseV : Letter
{
    public override string Name { get; } = "v";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 10.834806;
        double cy = 80.330268;

        AddRelativeBezier(newPoints, ref cx, ref cy, 9.72593, -8.16165, 18.7507, -12.6714, 30.2511, -11.43, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.90711, 0.313796, 4.06836, 0.48274, 6.69011, 1.35821, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.23434, 2.41571, 8.69461, 10.0027, 9.50163, 15.5984, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.27434, 8.83605, -1.54207, 18.1356, -3.5191, 27.0515, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.21375, 14.4932, -9.12986, 31.5478, -7.84755, 46.2493, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.343746, 3.94103, 0.851514, 7.1562, 2.17896, 10.7624, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.07705, 16.5091, 25.8294, 19.0214, 41.5723, 16.0662, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 11.0738, -2.07881, 20.2629, -7.9224, 28.2083, -15.7903, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 14.7287, -14.5851, 21.1398, -34.0432, 25.8862, -53.797, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.42545, -14.2564, 7.8191, -39.6279, 10.4801, -47.1219, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 154.006380;
        cy = 69.090276;

        AddRelativeBezier(newPoints, ref cx, ref cy, 5.98821, 7.98044, 7.72814, 12.7188, 15.7649, 16.2079, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.765, 0.766, 2.845, 0.810, 4.525, 1.031, pointsPerCurve);
        
        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}