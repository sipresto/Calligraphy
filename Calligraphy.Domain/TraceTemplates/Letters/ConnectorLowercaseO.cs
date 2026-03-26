namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseO : Letter
{
    public override string Name { get; } = "o";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 18.645700;
        double cy = 129.375100;

        AddRelativeBezier(newPoints, ref cx, ref cy, 1.30777, -1.63799, 2.34309, -2.19901, 3.88056, -3.34377, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.67985, -1.25079, 3.14109, -2.86095, 4.646, -4.35719, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.11116, -1.10475, 2.21527, -1.88298, 3.46789, -2.9096, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.97517, -2.43837, 4.39025, -3.48485, 7.76111, -5.63628, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.6879, -1.07729, 3.2214, -2.20999, 4.93889, -3.46762, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.39189, -1.01921, 2.69931, -1.88735, 4.23333, -2.69185, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.27104, -0.66658, 2.18162, -0.96899, 3.52778, -1.69175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.83078, -0.98295, 3.86568, -1.69424, 5.64445, -2.57504, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.34112, -2.14961, 10.1652, -4.30947, 14.8167, -6.06963, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.58688, -0.600502, 3.05161, -1.14898, 4.58611, -1.80118, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.21398, -0.515968, 2.2284, -0.867411, 3.52778, -1.1596, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.6232, -0.365008, 2.90162, -0.672138, 4.58611, -1.06813, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.16183, -0.508216, 4.49295, -1.06281, 6.70278, -1.46393, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.41214, -0.437829, 4.41738, -0.645245, 6.70278, -0.862889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.33196, -0.317315, 7.66875, 0.385549, 10.5833, 1.08964, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.56982, 0.379219, 2.80415, 0.619106, 4.58611, 1.23037, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.57523, 0.540364, 5.0256, 2.42922, 5.99722, 3.04706, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.23614, 1.4219, 5.09448, 4.08999, 7.81879, 7.26682, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 87.746668;
        cy = 91.787718;

        AddRelativeBezier(newPoints, ref cx, ref cy, -3.0627, 0.978988, -7.94506, 3.22043, -12.8292, 5.94544, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.0567, 1.1475, -3.51762, 2.48738, -5.29167, 3.88979, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.66242, 1.31415, -3.43192, 2.62762, -4.93889, 4.11657, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.03801, 1.02558, -1.81839, 1.78557, -2.80833, 2.82086, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.32508, 1.38577, -2.7234, 3.08257, -3.98128, 4.58612, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.46066, 2.94121, -5.00098, 5.48547, -7.02697, 8.46666, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.823389, 1.21159, -1.45483, 2.5799, -2.20812, 3.88056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.85366, 3.20061, -3.6014, 6.74246, -5.00096, 10.2306, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.6938, 4.22146, -2.86101, 8.28477, -3.7959, 12.7, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.820945, 3.87712, -1.28209, 7.8021, -1.78648, 11.6417, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.11541, 0.87854, -0.189329, 1.55304, -0.201705, 2.46944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.02077, 1.53826, -0.218951, 2.24193, -0.262677, 3.88056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.04705, 1.76305, 0.221686, 2.36193, 0.266214, 3.88055, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.03501, 1.19398, 0.179409, 1.73351, 0.288269, 2.82223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.0765, 0.76508, 0.06271, 1.36396, 0.161688, 2.11666, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.267807, 2.03665, 0.674027, 4.24178, 1.16068, 6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.442226, 1.91576, 0.842046, 3.2826, 1.57879, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.83449, 5.00263, 4.37404, 9.02165, 8.09592, 12.6948, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.95702, 2.91834, 6.20406, 4.8326, 10.2292, 6.45643, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.90097, 0.76688, 3.4409, 1.04526, 5.29167, 1.45928, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.36342, 0.52871, 4.87774, 0.78057, 7.05556, 0.94021, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.950448, 0.0697, 1.48634, 0.24148, 2.46944, 0.28471, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.972119, 0.0428, 1.54797, -0.10628, 2.46944, -0.2153, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.74928, -0.32528, 5.97768, -0.70316, 8.81945, -1.25078, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.79318, -0.53828, 5.2485, -1.30696, 8.11389, -2.52853, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.52986, -3.21007, 13.9916, -7.53895, 19.6687, -13.6674, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.97589, -2.13298, 4.27875, -4.72347, 5.99968, -6.99565, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.84606, -1.11707, 1.32933, -1.9881, 2.09244, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.50296, -2.33763, 3.07245, -4.87084, 4.41952, -7.40834, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.83895, -3.46404, 3.05286, -6.5909, 4.50854, -10.2305, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.3226, -0.8066, 1.61818, -3.97192, 2.52359, -6.62579, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 126.386160;
        cy = 102.525600;

        AddRelativeBezier(newPoints, ref cx, ref cy, 4.51597, 4.94912, 5.72216, 11.4923, 7.58537, 17.6703, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.05915, 5.75316, 1.61104, 10.458, 1.64127, 16.9597, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.0271, 5.81531, -0.84468, 11.4493, -2.75121, 19.4566, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 127.106520;
        cy = 103.377300;

        AddRelativeBezier(newPoints, ref cx, ref cy, 3.5236, 2.88672, 5.2786, 3.59524, 7.72273, 4.41874, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.5431, 1.19378, 5.99394, 1.63167, 11.2575, 1.93004, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}