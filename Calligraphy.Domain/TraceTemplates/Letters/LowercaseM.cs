namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseM : Letter
{
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);
    
    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 1.208928;
        double cy = 105.46216;

        AddRelativeBezier(newPoints, ref cx, ref cy, 13.388459, -9.585145, 39.745539, -15.605062, 38.669743, 7.76111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.467714, 10.15873, -2.760652, 20.2151, -5.419253, 29.28055, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.818828, 16.4315, -7.913724, 34.2496, -12.436601, 51.15278, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 35.788095;
        cy = 137.9708;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.313242, -5.29271, 8.59245, -18.42904, 16.724237, -26.41183, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 8.561273, -8.40439, 22.827505, -15.161583, 35.486874, -13.513127, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 12.904874, 1.680425, 20.216694, 9.898847, 21.045614, 22.286067, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.54989, 23.16111, -9.36097, 53.42716, -16.106725, 75.84722, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 107.95208;
        cy = 140.11023;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.38931, -5.79676, 6.28609, -14.39157, 11.65978, -21.4234, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.46624, -7.15292, 11.61082, -13.05414, 19.93129, -16.54246, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.83809, -3.286082, 15.98491, -4.185773, 24.34167, -2.14032, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 10.66442, 2.61028, 16.32928, 11.4508, 17.07072, 22.21056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.40898, 20.44706, -12.57862, 40.41744, -10.89767, 60.67778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.92871, 23.24675, 26.20436, 14.1203, 38.9825, 6.35, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}