namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseN : Letter
{
    public override string Name { get; } = "n";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 24.998134;
        double cy = 103.707410;

        AddRelativeBezier(newPoints, ref cx, ref cy, 10.7637, -7.53254, 33.6895, -17.609, 39.8388, -0.70545, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.15372, 3.17144, 1.56807, 5.44528, 1.67207, 9.17212, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.247197, 8.85815, -2.34007, 18.6721, -4.54058, 27.1639, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.66869, 18.0165, -6.8086, 40.1972, -12.9814, 58.2083, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 62.764909;
        cy = 136.013210;

        AddRelativeBezier(newPoints, ref cx, ref cy, 1.89235, -4.27149, 7.70206, -15.934, 14.2678, -22.7886, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.32149, -6.59949, 11.7227, -12.2552, 20.4929, -16.0975, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.94661, -3.48141, 16.6739, -4.49421, 25.4, -3.25696, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 13.3706, 1.89578, 21.3043, 10.8892, 22.4168, 24.3765, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.74986, 21.2153, -12.0748, 42.9767, -10.0214, 63.8528, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.36051, 23.9985, 27.5268, 16.4739, 41.2268, 6.35, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}