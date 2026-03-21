namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseB : Letter
{
    public LowercaseB()
    {
        IsTall = true;
    }

    public override string Name { get; } = "b";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);
    
    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 85.678042;
        double cy = 113.098880;
        
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.886983, -4.43459, 2.585967, -13.06879, 3.933558, -19.374592, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.541173, -16.570182, 13.03017, -46.226462, 31.33265, -42.88303, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 8.8382, 1.614526, 11.74665, 10.626178, 12.23944, 19.329607, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.71383, 12.607405, -3.4445, 23.84588, -9.61008, 34.570345, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -20.87106, 36.30333, -59.439429, 68.28225, -87.973594, 97.63274, pointsPerCurve);
        
        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];
        
        cx = 85.874387;
        cy = 112.242170;
        
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.804401, 7.85234, -5.702077, 24.98133, -7.356438, 33.989, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.877503, 21.11217, -12.898389, 45.13707, -13.075128, 67.61251, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.101731, 12.93644, 6.770731, 21.58288, 19.373421, 23.0768, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.219857, 0.7373, 12.315077, -0.31892, 17.988448, -2.81737, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 20.50577, -9.03033, 27.93418, -31.99111, 32.45427, -52.78654, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.78842, -8.22794, 4.77297, -24.04896, 6.69705, -29.96878, pointsPerCurve);
        
        rawPoints.AddRange(newPoints);
        newPoints = [];
        
        cx = 142.040010;
        cy = 151.697910;
        
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.79459, 7.73825, 16.45571, 13.15432, 27.51666, 9.87778, pointsPerCurve);
        
        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}