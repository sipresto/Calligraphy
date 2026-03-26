namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseF : Letter
{
    public ConnectorLowercaseF()
    {
        IsTall = true;
        IsLow = true;
    }

    public override string Name { get; } = "f";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 109.407590;
        double cy = 77.007441;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.96512, -12.8161, 5.39841, -24.8407, 6.39432, -29.3496, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.58996, -2.67105, 1.13317, -5.12908, 1.73721, -7.76111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.13404, -4.94149, 2.57271, -10.4746, 4.90323, -15.1694, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.3764, -2.77276, 2.73185, -5.26766, 4.5548, -7.76111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.55018, -2.12035, 3.81937, -4.45832, 5.94116, -5.91936, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.25916, -0.867044, 2.31406, -1.43852, 3.88056, -1.9215, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.57252, -0.484833, 2.21843, -0.500314, 3.52777, -0.71264, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.69769, -0.11315, 3.39501, -0.188317, 4.23334, -0.057705, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.39291, 0.21702, 2.10716, 0.279483, 3.52778, 0.670179, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.99758, 0.549364, 3.26388, 1.44567, 4.85967, 3.3552, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.09408, 1.30918, 1.56778, 2.48859, 2.2133, 4.23305, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.83796, 2.26446, 1.20766, 4.45931, 1.38497, 7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.18761, 2.74699, 0.23834, 6.45719, -0.0525, 9.17222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.17631, 1.64568, -0.61706, 2.98854, -0.84603, 4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.29413, 2.05211, -0.25959, 3.37865, -0.80736, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.30326, 1.05909, -0.62987, 1.90755, -1.08854, 3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.40711, 1.12493, -0.75054, 2.3935, -1.15415, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.50174, 1.40999, -0.84597, 2.88139, -1.47481, 4.23333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.99223, 2.13318, -1.8666, 4.18833, -2.94744, 6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.48367, 2.96735, -3.30106, 6.03071, -5.28322, 8.81945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.45321, 2.04454, -1.97619, 3.02464, -3.70663, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.32832, 3.05031, -4.59021, 5.83296, -7.29863, 8.81945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.33203, 1.4688, -3.1769, 3.81807, -4.36889, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.87174, 1.07769, -1.58018, 2.05339, -2.49258, 3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.20196, 1.47756, -2.26666, 2.30044, -3.58467, 3.8792, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.36551, 1.63565, -2.54159, 2.82625, -3.84109, 4.20448, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.81378, 0.863081, -1.40344, 1.29456, -2.30612, 2.17844, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.49001, 1.45899, -2.51749, 3.14499, -4.27852, 4.84716, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.73656, 0.71195, -1.3467, 1.15398, -2.08509, 1.75491, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.16048, 0.94446, -2.34693, 2.1057, -3.52778, 3.14343, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.5256, 1.34069, -2.77883, 2.33522, -4.23334, 3.6549, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.67857, 3.33759, -7.05646, 6.72375, -10.5833, 10.2028, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.82827, 3.77634, -8.13847, 7.16109, -11.9944, 10.9375, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 109.446830;
        cy = 76.803189;

        AddRelativeBezier(newPoints, ref cx, ref cy, -3.56747, 15.8351, -6.58408, 29.9264, -8.85345, 40.9427, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.28885, 1.40217, -0.52246, 3.38763, -0.832679, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.370122, 1.85082, -0.690247, 3.17939, -1.11767, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.667369, 2.74724, -1.23521, 5.1964, -1.84555, 7.76111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.528941, 2.22265, -0.805248, 5.45901, -1.41601, 7.76111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.371112, 1.39881, -0.548868, 2.22204, -0.748027, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.211787, 1.38859, -0.973907, 4.18365, -1.2897, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.819901, 3.79268, -2.07283, 7.6469, -2.74274, 11.6417, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.668381, 3.98564, -1.73028, 8.30078, -2.55274, 12.3472, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.17284, 15.6102, -6.99158, 31.4597, -10.1598, 47.2722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.2996, 11.4773, -6.13823, 23.1561, -6.13823, 34.925, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0, 2.39766, 0.10851, 5.08535, 0.587691, 7.40834, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.369066, 1.78914, 0.672224, 3.13688, 1.49386, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.638193, 1.39967, 1.26562, 2.60307, 2.54132, 3.76458, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.07913, 0.98259, 2.15969, 1.50256, 3.49102, 2.01405, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.33114, 0.89561, 4.16254, 1.17891, 7.05556, 0.72353, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.66622, -0.26228, 2.93674, -0.51502, 4.58611, -1.14246, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.81317, -0.68973, 3.13647, -1.57578, 4.58611, -2.68855, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.21648, -1.70142, 4.31337, -3.90848, 5.99233, -6.19893, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.18381, -2.97919, 3.37057, -5.54893, 4.86239, -8.81945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.83839, -1.83798, 1.72025, -4.85537, 2.20704, -6.70278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.31213, -1.18451, 0.6476, -1.88914, 0.99329, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.53096, -9.4145, 1.83173, -23.8751, 1.75203, -33.5048, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 94.968746;
        cy = 145.282910;

        AddRelativeBezier(newPoints, ref cx, ref cy, 3.60509, 10.5679, 4.69963, 13.8018, 7.39573, 22.9528, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.15829, 13.4644, 8.4274, 32.7924, 9.55078, 47.0067, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 94.692816;
        cy = 145.452210;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.04612, 1.50478, 7.62097, 6.04326, 11.2889, 7.37675, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.94448, 0.70693, 3.38137, 1.00296, 8.08759, 0.29346, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}