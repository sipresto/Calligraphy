namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseU : Letter
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
        
        double cx = 52.656074;
        double cy = 84.960210;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.87977, 5.93327, -5.60963, 22.5699, -7.36756, 30.3389, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.76778, 21.0706, -15.1987, 45.4154, -13.6412, 67.0278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.512243, 7.10809, 1.04333, 12.3053, 5.53268, 18.696, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 10.597, 15.085, 35.2562, 14.7888, 51.1066, 8.63986, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 11.9393, -4.63171, 21.4257, -13.0282, 29.3534, -23.4553, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.71478, -6.20124, 8.2837, -11.6035, 11.5732, -17.9917, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.34062, -6.4875, 6.06484, -18.6244, 7.97669, -26.4583, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.01956, -16.4705, 7.97883, -35.7253, 12.8329, -52.2111, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 132.514920;
        cy = 159.648650;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.44332, 6.02095, -5.67933, 22.3698, -5.6424, 32.8083, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.0194, 5.48086, 0.95033, 12.8517, 5.252, 17.5055, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 11.0533, 11.9581, 36.4166, 0.60244, 44.8404, -7.27497, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}