namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseA : Letter
{
    public override string Name { get; } = "a";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 25.766988;
        double cy = 114.831990;

        AddRelativeBezier(newPoints, ref cx, ref cy, 5.85285, -6.13615, 7.40815, -7.29432, 13.0373, -13.2681, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.33494, -1.43873, 7.1376, -7.43428, 8.65958, -8.95567, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.33009, -3.32882, 7.2052, -7.81214, 10.8067, -10.6754, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 8.05124, -6.40084, 16.7362, -11.7344, 26.5263, -14.8372, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 9.31541, -2.95234, 19.3477, -4.40363, 29.2806, -2.98065, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.74225, 0.249597, 3.45351, 0.556125, 5.29167, 0.924406, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.00929, 0.803267, 8.34185, 2.04049, 11.9944, 3.92412, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.48672, 1.28239, 6.35946, 2.77399, 8.41005, 3.67286, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.53218, 0.233277, 0.89548, 0.360056, 1.11495, 0.44642, pointsPerCurve);
        
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 143.197510;
        cy = 64.655468;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.72108, 2.96332, -1.89191, 6.73844, -2.97058, 10.5833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.27125, 0.966845, -0.44987, 1.80478, -0.64921, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.25683, 1.31086, -0.63327, 2.08239, -0.9067, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.82757, 4.37467, -1.8497, 8.69197, -2.72343, 13.0528, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.1004, 5.49221, -2.5659, 11.1662, -3.68728, 16.5806, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.2108, 1.01778, -0.41628, 1.81026, -0.65847, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.7944, 7.49772, -2.79632, 14.088, -5.05349, 21.1667, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.77499, 2.43043, -1.56063, 4.74405, -2.77077, 7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.20087, 2.29378, -3.31871, 5.32711, -4.51616, 7.40833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.99246, 3.46297, -4.16166, 7.13296, -6.67093, 10.1707, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.40305, 1.69853, -2.12429, 1.99714, -3.51035, 3.58767, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.8305, 0.953, -1.73248, 2.18643, -2.63169, 3.17364, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.54837, 3.8957, -8.05928, 7.56797, -12.6398, 10.123, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.36674, 1.32018, -4.43436, 2.37382, -7.05556, 3.44477, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.316, 1.76338, -8.03482, 2.28948, -12.3472, 2.72094, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.38439, 0.13851, -3.11259, 0.44584, -4.58611, 0.58607, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.09267, 0.2943, -6.46039, -0.37708, -9.525, -0.64567, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.34263, -0.29296, -6.02718, -1.01, -9.17222, -2.02983, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.41087, -0.78176, -4.06492, -1.76333, -5.99722, -2.83719, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.78088, -0.98973, -4.13095, -3.15146, -5.64445, -4.65824, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.29992, -3.28529, -5.71945, -6.72509, -7.27332, -10.9359, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.16205, -3.14902, -1.8567, -6.09726, -2.48605, -9.17223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.663198, -3.24035, -1.28899, -7.33935, -1.16259, -10.5833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.03195, -0.82001, 0.145814, -1.33619, 0.237906, -2.11667, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.125046, -1.05981, 0.05667, -2.08359, 0.1606, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.281384, -2.9548, 0.613136, -5.90328, 1.11305, -8.81945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.359501, -2.09712, 1.14377, -4.65452, 1.70509, -6.70277, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.11816, -4.08015, 2.91934, -6.52143, 4.40782, -10.2306, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.05089, -2.61873, 2.08983, -5.02008, 3.51063, -7.40834, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.915555, -1.53897, 1.8364, -2.81787, 2.78004, -4.23333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.31321, -1.96982, 2.64881, -4.49452, 4.17835, -6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.01269, -1.22849, 2.1046, -2.33147, 3.15976, -3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.17847, -3.60367, 6.87162, -6.72356, 10.4826, -9.87778, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 126.919910;
        cy = 133.654960;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.68674, 2.11053, -1.15325, 3.84735, -1.61582, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.29819, 1.15849, -0.55801, 1.99165, -0.76543, 3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.24503, 1.39787, -0.31417, 2.26224, -0.5504, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.35678, 1.91133, -1.10934, 4.09752, -1.2712, 5.99722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.34384, 4.03565, -0.75757, 7.8286, -0.73577, 12.3472, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.02, 4.14611, 0.21136, 6.47907, 1.67896, 10.2306, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.86803, 2.21888, 1.91175, 4.32575, 3.99679, 6.24411, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.58432, 1.45768, 3.62478, 2.61371, 5.61287, 3.06394, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.84584, 0.41802, 3.39969, 0.75077, 5.29166, 1.01807, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.87563, 0.68876, 10.1041, -0.69578, 14.8167, -2.33362, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.56114, -1.93275, 11.7929, -5.35584, 16.2278, -9.40361, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}