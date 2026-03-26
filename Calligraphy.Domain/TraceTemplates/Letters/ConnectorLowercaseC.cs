namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseC : Letter
{
    public override string Name { get; } = "c";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 42.797852;
        double cy = 114.945510;

        AddRelativeBezier(newPoints, ref cx, ref cy, 1.1703, -1.14614, 2.98528, -2.72213, 4.23333, -3.85415, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.908434, -0.82397, 1.57483, -1.3413, 2.46944, -2.17465, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.19934, -1.1172, 1.89199, -1.86042, 3.175, -3.14343, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.43429, -1.43429, 2.32575, -2.32575, 3.88056, -3.88055, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.70063, -1.70063, 3.3125, -3.3125, 4.93889, -4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.42075, -1.42075, 2.32587, -2.32647, 3.88056, -3.88056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.27666, -2.27579, 3.86368, -3.32095, 5.96565, -5.35183, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.52045, -1.46903, 3.50855, -3.81757, 4.97047, -5.21762, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.00673, -0.964132, 1.80337, -1.66674, 2.97193, -2.73538, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.22202, -1.11755, 2.09596, -1.75594, 3.37807, -2.86688, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.16244, -1.87374, 4.86106, -3.95079, 7.40833, -5.48847, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.45181, -2.0837, 7.19908, -4.23301, 10.9361, -5.61613, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.57702, -0.953775, 6.24006, -2.12698, 8.81945, -2.35703, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.43251, -0.127748, 2.62756, -0.281034, 4.23333, -0.502209, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.04273, -0.281357, 6.77657, -0.107638, 8.46667, 0.09472, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.63858, 0.315915, 5.02545, 0.39498, 7.76111, 1.3994, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.31165, 1.2159, 6.47004, 2.44098, 9.17223, 4.62939, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.90291, 0.731244, 1.63093, 1.34357, 2.46808, 2.1537, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.84582, 0.818512, 1.48239, 1.4615, 2.22091, 2.45556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.29335, 1.74089, 1.8984, 3.37393, 3.07212, 5.29167, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 71.162490;
        cy = 87.772688;

        AddRelativeBezier(newPoints, ref cx, ref cy, -3.40074, 4.19022, -9.31225, 12.6434, -11.6218, 17.5355, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.925342, 1.9601, -2.00373, 4.44555, -2.91733, 6.50894, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.58096, 3.57065, -2.39847, 5.89059, -3.53258, 9.36606, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.09752, 3.60473, -2.19071, 7.92559, -2.79908, 11.6417, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.200435, 1.22433, -0.312417, 2.29748, -0.411302, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.06649, 0.82717, -0.18407, 1.29064, -0.262678, 2.11667, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.111642, 1.17314, -0.06041, 2.16514, -0.05989, 3.52777, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.0011, 2.93974, 0.205667, 4.84116, 0.556114, 7.40834, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.183505, 1.34425, 0.524182, 2.83481, 0.796474, 4.23333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.3448, 1.77091, 0.711907, 3.05542, 1.33489, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.93108, 2.81499, 2.76497, 6.84108, 4.47016, 9.17223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.754541, 1.0315, 1.46847, 1.82915, 2.34966, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.792437, 0.89305, 1.33835, 1.60604, 2.16594, 2.45556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.934762, 0.95952, 1.77025, 1.60733, 2.79065, 2.48307, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.26679, 2.80362, 6.71174, 4.70727, 10.9361, 6.39789, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.41116, 0.96497, 4.358, 1.42659, 6.70278, 1.85236, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.34181, 0.24366, 2.90942, 0.48322, 4.23333, 0.55692, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.22426, 0.0682, 1.8634, 0.18061, 3.175, 0.30543, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.43357, 0.13643, 4.30066, 0.12032, 5.64445, 0.0283, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.899483, -0.0616, 1.46845, -0.22071, 2.46944, -0.28965, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.73921, -0.32636, 9.79798, -1.27501, 14.4639, -2.73129, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.60137, -0.81193, 5.63719, -1.76318, 8.11389, -2.92431, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.77212, -1.76841, 7.37051, -3.67163, 10.9361, -5.82355, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.09576, -1.86836, 6.13794, -4.64269, 9.17222, -6.19131, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}