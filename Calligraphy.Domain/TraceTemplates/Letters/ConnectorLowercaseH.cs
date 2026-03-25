namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseH : Letter
{
    public ConnectorLowercaseH()
    {
        IsTall = true;
    }

    public override string Name { get; } = "h";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 98.140115;
        double cy = 77.222136;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.27081, -11.4005, 5.06125, -26.9199, 9.66229, -37.6702, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.34442, -5.13748, 4.6575, -10.099, 8.45986, -14.4639, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.31834, -2.66129, 6.08399, -5.65334, 9.42292, -6.41507, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.85983, -0.424285, 2.3476, -0.485587, 3.88056, -0.658186, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.988, -0.111233, 1.53091, -0.27199, 2.46944, -0.271926, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.6732, 4.3e-05, 1.11756, 0.102987, 1.76389, 0.194088, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.49226, 0.210324, 2.39189, 0.322268, 3.88056, 0.665528, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.86003, 0.428893, 4.12229, 1.78081, 5.46179, 3.34351, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.3865, 1.61754, 2.32382, 3.26699, 3.00324, 5.25872, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.60315, 1.76819, 0.85644, 2.90303, 1.23663, 4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.4533, 2.00675, 0.6594, 4.58796, 0.63125, 6.70278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.10285, 7.7269, -2.00619, 14.4463, -4.84689, 21.5194, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.272, 3.16718, -3.22321, 6.18767, -4.88935, 9.17222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.90918, 5.21116, -6.84365, 10.1817, -10.6116, 14.8167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.29863, 5.28768, -8.82452, 10.192, -13.3283, 15.1694, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.29341, 3.63979, -7.68688, 7.89702, -11.2238, 11.257, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.5251, 3.99199, -9.13271, 8.4969, -13.5112, 12.9839, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.69244, 4.88884, -8.98683, 8.74001, -22.1246, 21.6202, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 98.328902;
        cy = 76.562212;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.67636, 14.6719, -5.87419, 29.9211, -7.46181, 37.4594, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.17821, 19.8389, -6.37494, 27.4496, -8.43753, 36.0583, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.937252, 3.91182, -2.07152, 8.71289, -3.01522, 12.7, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.703057, 2.97039, -1.46072, 5.74487, -2.12538, 8.81944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.27071, 5.87807, -2.7287, 12.4666, -4.07763, 18.3444, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.65508, 7.21192, -3.31251, 14.608, -4.81586, 21.8722, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 78.524762;
        cy = 165.980250;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0.370391, -1.31751, 0.495781, -2.22055, 1.26276, -4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.565469, -2.00416, 1.28199, -3.52136, 2.25522, -5.64444, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.21599, -4.83417, 4.02186, -7.54793, 6.83071, -11.2889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.39577, -1.85896, 2.91285, -3.94422, 4.52787, -5.49474, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.71691, -1.64834, 3.5814, -3.13365, 5.58455, -4.70751, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.45755, -2.71655, 7.60776, -5.13785, 11.6417, -6.5528, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.03299, -2.11613, 12.4764, -2.68465, 19.05, -1.88747, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.91275, 0.23197, 3.23307, 0.49278, 5.29166, 1.18573, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.0191, 1.01627, 5.81069, 2.70645, 8.08096, 5.11473, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.77492, 1.88282, 2.89775, 4.01937, 3.7499, 6.34483, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.12494, 3.06988, 1.35128, 5.80574, 1.54177, 9.17223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.25543, 4.51415, -0.6654, 9.77933, -1.78567, 14.1111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.70775, 2.7367, -1.27493, 5.63934, -1.91196, 8.46667, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.22566, 1.00154, -0.39447, 1.84353, -0.6348, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.47392, 1.93, -0.94881, 4.51749, -1.4288, 6.70278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.83793, 3.81488, -1.85869, 7.69053, -2.26011, 11.6417, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.29716, 2.92493, -0.6492, 5.96406, -0.20416, 8.81944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.26946, 1.72886, 0.44851, 2.92836, 0.86507, 4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.41803, 1.66355, 1.18923, 3.23241, 2.32409, 4.55427, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.31066, 1.52665, 2.59193, 2.32602, 4.36372, 2.7694, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.78086, 0.44567, 2.95513, 0.73952, 4.93888, 0.78506, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.5823, 0.0822, 6.93946, -0.56125, 10.2306, -1.90081, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.81224, -1.55168, 8.12319, -3.71048, 11.2889, -6.56069, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}