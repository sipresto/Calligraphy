namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseA : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 155.1756;
        double cy = 104.12781;
        
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.22447, 3.75727, -0.53594, 6.38143, -0.9735, 10.93611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.22073, 23.11592, -9.66282, 56.16806, -21.25568, 71.61389, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -13.85384, 18.45826, -37.681967, 31.93595, -61.731931, 22.19565, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -19.084694, -7.72935, -22.416688, -29.69462, -18.884857, -48.65399, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.94757, -15.82296, 11.820344, -30.90454, 23.825759, -41.78788, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 10.956437, -9.93241, 23.109108, -17.10522, 37.745209, -19.619349, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 10.71373, -1.84037, 25.28811, 1.360149, 34.925, 3.508009, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.77228, 0.61789, 3.34433, 1.37887, 5.96046, 0.89829, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.16819, -0.39829, 3.40334, -2.56284, 3.91732, -3.324066, pointsPerCurve);
        
        rawPoints.AddRange(newPoints);
        newPoints = [];
        
        cx = 139.43144;
        cy = 175.59396;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.1124, 6.27212, 0.33021, 8.48451, 1.02722, 14.80299, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.60559, 32.68554, 29.61743, 21.67742, 44.74296, 7.8641, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints, screenWidth: 1200, screenHeight: 800, marginY: 150);
    }
}