namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseX : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 39.054522;
        double cy = 111.464290;

        AddRelativeBezier(newPoints, ref cx, ref cy, 8.28679, -4.53686, 15.6183, -7.4771, 25.0472, -6.75924, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 11.7003, 0.89079, 20.3093, 7.05827, 24.549, 18.7537, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.68855, 4.65801, 2.41877, 7.85396, 2.57934, 12.7, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.564263, 17.0294, -0.960418, 31.9145, -7.52785, 46.9194, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.493, 5.69591, -5.02161, 8.85415, -8.37937, 13.7583, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -13.7003, 20.0101, -43.3437, 33.178, -60.61, 11.2889, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 152.245560;
        cy = 203.860630;

        AddRelativeBezier(newPoints, ref cx, ref cy, -15.9057, 16.218, -50.9143, 27.2426, -61.2942, -0.35278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.35799, -14.2444, -3.07348, -28.1651, -0.844016, -43.0389, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.825607, -5.50799, 2.15195, -10.0065, 4.41255, -15.1694, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 11.7933, -26.9343, 39.6001, -56.7448, 67.6035, -29.6333, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}