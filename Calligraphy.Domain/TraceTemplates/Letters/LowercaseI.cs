namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseI : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 101.55988;
        double cy = 106.93778;

        AddRelativeBezier(newPoints, ref cx, ref cy, -8.726282, 25.50099, -20.781543, 65.72189, -19.241327, 92.42778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.196564, 3.4083, 0.602892, 5.77127, 1.685954, 8.81934, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.621732, 18.63566, 32.366073, 7.49211, 42.955373, -1.05823, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 108.06708;
        cy = 72.057289;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0, 0.117, 0, 0.235, 0, 0.352778, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}