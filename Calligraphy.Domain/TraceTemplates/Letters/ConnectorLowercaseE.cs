namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseE : Letter
{
    public override string Name { get; } = "e";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 63.056642;
        double cy = 95.368528;

        AddRelativeBezier(newPoints, ref cx, ref cy, 5.63651, -8.26055, 12.9021, -16.4813, 21.1667, -22.4267, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.63553, -2.61537, 7.54249, -4.90315, 11.6417, -6.74608, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.70992, -1.21834, 6.04067, -2.25288, 8.81944, -2.76641, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.71623, -0.317164, 3.73546, -0.412357, 5.64445, -0.666088, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.81446, -0.374073, 6.40102, -0.01714, 9.17222, 0.13718, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.51062, 0.195509, 6.80235, 1.04438, 10.2306, 2.13928, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.52756, 1.12663, 5.72531, 2.4722, 8.4615, 5.28159, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.62658, 1.6701, 2.61196, 2.88643, 3.24033, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.64871, 2.48307, 0.67308, 3.09824, 1.08501, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.14013, 0.866115, 0.87136, 6.58108, -1.33062, 12.1698, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.38584, 3.5173, -2.39715, 5.19955, -6.67685, 8.7296, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.61086, 2.15353, -7.70812, 4.74886, -17.9621, 9.41788, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -31.6949, 14.4319, -45.3915, 18.3183, -77.5622, 31.2648, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 132.292020;
        cy = 174.899720;

        AddRelativeBezier(newPoints, ref cx, ref cy, -5.89913, 4.89643, -13.4015, 8.4763, -20.4611, 11.2889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -10.3388, 4.11905, -19.5019, 4.85234, -30.6917, 4.58612, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.53375, -0.10788, -8.77367, -1.3785, -13.0528, -2.62052, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.18872, -0.92554, -5.61036, -2.09535, -8.11389, -3.88029, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.10531, -2.21397, -6.15599, -4.56971, -8.46531, -7.61166, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.840431, -1.10706, -1.88287, -2.42886, -2.57288, -3.52643, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.40272, -2.23126, -2.65355, -5.05535, -3.37071, -7.76111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.699861, -2.64051, -0.4214, -3.40928, -1.0371, -5.64444, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.34079, -1.23717, -0.726862, -2.16428, -0.91624, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.219587, -1.17194, -0.225551, -3.30055, -0.362854, -4.58612, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.219647, -2.05652, 0.09746, -2.16558, 0.13937, -3.88055, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.03351, -1.37154, -0.05575, -1.82428, 0.03675, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.05833, -0.85172, 0.234208, -1.66475, 0.289625, -2.46945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.10921, -1.58586, 0.517728, -4.39149, 0.788034, -5.99722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.239913, -1.42518, 0.525662, -2.14424, 0.791575, -3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.370935, -1.92998, 0.86185, -3.69246, 1.50937, -5.64444, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.63588, -4.93144, 2.9691, -8.91213, 5.38096, -13.7583, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.4772, -0.95884, 5.126, -9.12718, 10.8512, -18.2164, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}