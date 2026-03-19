namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseE : Letter
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
        
        double cx = 70.436744;
        double cy = 139.889280;

        AddRelativeBezier(newPoints, ref cx, ref cy, 1.682761, -4.20464, 6.766188, -14.52188, 14.838532, -23.90954, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 13.450362, -15.64201, 45.595614, -33.732448, 63.276864, -14.78418, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 8.58769, 9.20306, 2.33124, 25.83897, -5.34477, 34.47319, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -12.93906, 14.55426, -34.55458, 22.68222, -52.432683, 29.24035, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.86526, 2.15152, -24.420435, 7.90315, -27.351027, 8.73481, pointsPerCurve);
        
        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];
        
        cx = 70.975096;
        cy = 138.449200;

        AddRelativeBezier(newPoints, ref cx, ref cy, -3.728148, 8.31407, -6.204585, 16.72843, -6.980732, 25.75278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.636509, 7.40072, -0.189125, 14.91317, 2.456869, 22.225, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 12.154211, 33.58641, 58.319097, 22.99963, 80.723867, 7.05556, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}