namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseT : Letter
{
    public LowercaseT()
    {
        IsTall = true;
    }
    
    public override string Name { get; } = "t";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);
    
    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 106.312990;
        double cy = 35.129524;

        AddRelativeBezier(newPoints, ref cx, ref cy, -12.998343, 38.370375, -18.687294, 84.316016, -27.203592, 124.177776, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.96491, 23.239, -15.0735, 49.6407, -14.2514, 73.025, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.1459, 4.15029, 0.496191, 6.37283, 1.71114, 9.87778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.00851, 20.2185, 34.1694, 8.12571, 46.4467, -1.05833, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 63.973546;
        cy = 130.820500;

        AddRelativeBezier(newPoints, ref cx, ref cy, 4.48178, -2.21582, 13.9124, -2.943, 19.4028, -3.68097, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 12.5399, -1.68551, 26.2328, -4.51594, 39.1583, -5.84403, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}