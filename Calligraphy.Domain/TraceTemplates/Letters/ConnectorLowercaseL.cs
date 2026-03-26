namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseL : Letter
{
    public ConnectorLowercaseL()
    {
        IsTall = true;
    }

    public override string Name { get; } = "l";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 102.968220;
        double cy = 78.931099;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0.21187, -0.820966, 2.67282, -11.3834, 2.9342, -12.4289, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.84875, -3.39501, 1.50526, -6.82112, 2.29033, -10.2306, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.52068, -6.60412, 2.92633, -12.941, 5.73455, -19.05, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.20072, -4.78746, 4.82205, -9.52664, 8.23528, -13.4042, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.08248, -1.22975, 2.70394, -2.6507, 3.97992, -3.56098, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.42928, -1.01964, 2.79363, -1.90555, 4.58611, -2.54349, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.01843, -0.718367, 3.69118, -0.791533, 5.64444, -1.04662, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.06172, -0.138666, 2.95359, 0.02719, 3.88056, 0.181276, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.53343, 0.254894, 2.40817, 0.228109, 4.23333, 0.945378, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.25116, 0.491701, 2.47253, 1.16326, 3.46271, 2.17954, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.47504, 1.5139, 2.63776, 3.4235, 3.46138, 5.60743, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.71367, 1.89241, 0.94897, 3.58109, 1.2358, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.60071, 4.32133, 0.28303, 9.02387, -0.0762, 13.4056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.39636, 4.83453, -1.87528, 9.25676, -4.16801, 13.7583, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.6419, 7.15053, -8.24395, 14.6721, -13.2251, 20.8139, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.89625, 1.1051, -1.39835, 1.78704, -2.21275, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.69642, 0.885218, -1.31095, 1.59652, -2.02058, 2.46944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.76575, 0.941932, -1.27642, 1.61993, -2.03964, 2.46944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.72364, 0.805463, -1.29752, 1.34268, -1.99662, 2.11667, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.98445, 2.19707, -3.77464, 4.39568, -5.70569, 6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.00786, 2.03205, -4.01094, 4.0588, -5.96564, 6.02853, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.08166, 2.09767, -4.51898, 4.98542, -6.73436, 6.95919, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.19065, 1.06079, -2.00361, 1.49144, -3.17364, 2.56743, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.90459, 2.67113, -6.85686, 6.66473, -9.87778, 9.28901, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.01078, 1.74677, -3.1741, 2.7106, -5.14196, 4.82075, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.61731, 3.87889, -8.39876, 7.88302, -12.1442, 11.6104, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.52854, 1.52116, -3.69623, 3.86898, -4.93889, 5.2914, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 103.060050;
        cy = 78.768210;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.11354, 0.404024, -0.20945, 0.600222, -0.472, 1.77259, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.28188, 1.25869, -1.08622, 5.46577, -1.3839, 7.04686, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.65442, 3.47593, -1.83346, 7.20535, -2.46944, 10.5833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.527918, 2.80407, -1.09375, 6.04212, -1.87631, 8.81945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.283618, 1.00657, -0.526734, 1.75273, -0.753464, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.351249, 1.65687, -0.74526, 3.32512, -1.11686, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.613787, 2.66561, -1.17566, 5.77995, -1.85046, 8.46667, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.05885, 16.1604, -7.80983, 33.1904, -11.2432, 49.7417, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.91928, 4.43165, -2.21314, 8.94573, -2.76832, 13.4056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.25975, 2.08665, -0.439874, 4.46002, -0.659833, 6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.169822, 1.45917, 0.03595, 2.53611, 0.19735, 3.88055, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.190869, 1.58996, 0.356503, 2.86796, 0.894196, 4.58612, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.610396, 1.95046, 1.42137, 3.65888, 3.05523, 5.08179, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.20245, 1.0472, 2.36573, 1.69536, 3.8664, 2.12918, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.41019, 0.40768, 2.32644, 0.53653, 3.88056, 0.75157, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.52864, 0.48828, 7.09828, -0.39841, 10.2306, -1.6139, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.00442, -1.55393, 8.28979, -3.80125, 11.6417, -6.70142, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}