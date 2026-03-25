namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseJ : Letter
{
    public ConnectorLowercaseJ()
    {
        IsLow = true;
    }

    public override string Name { get; } = "j";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 129.946300;
        double cy = 56.221481;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.55475, 12.3775, -5.81793, 25.6467, -8.54099, 38.4528, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.94322, 4.43579, -1.74211, 8.93247, -2.95097, 13.4056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.37984, 1.40552, -3.5537, 17.217, -5.07769, 24.8039, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.53065, 7.62015, -3.0872, 14.8332, -6.05506, 27.1984, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.8817, 12.0062, -2.91245, 15.4906, -6.35783, 29.4671, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 147.508420;
        cy = 113.655260;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.06489, 1.39301, -5.03708, 3.35805, -7.40834, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.43495, 3.62331, -11.9061, 7.98564, -17.2861, 11.4509, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.29693, 0.83534, -2.21383, 1.27488, -3.52778, 2.21794, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.87326, 1.34448, -3.10629, 2.40436, -4.93889, 3.79234, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.03676, 0.78524, -1.7817, 1.14803, -2.82222, 1.84801, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.95181, 0.64029, -1.84091, 1.36396, -2.82223, 2.00207, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.81755, 1.18191, -3.86608, 2.63695, -5.64444, 3.68484, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.88203, 1.69823, -4.44374, 2.43006, -7.05556, 4.36943, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.17744, 0.8743, -2.38321, 1.68603, -3.52778, 2.59657, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.37632, 2.68595, -7.07435, 5.31221, -10.2292, 8.28619, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.81473, 1.71071, -3.4039, 3.53458, -4.99987, 5.26527, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.878241, 0.95237, -1.46233, 1.50587, -2.22853, 2.46428, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.628063, 0.78561, -1.02757, 1.37819, -1.62588, 2.11666, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.70562, 0.87094, -1.32189, 1.57687, -1.9822, 2.46945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.03413, 1.39791, -1.94328, 2.69105, -2.90007, 4.23333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.29138, 2.08164, -2.28485, 3.83881, -3.21556, 5.99722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.68868, 3.91628, -2.59631, 8.09807, -3.66035, 11.9945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.302964, 1.10943, -0.530857, 1.75388, -0.749653, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.21127, 1.03159, -0.341398, 1.84022, -0.552303, 2.82223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.284543, 1.32489, -0.257661, 2.57114, -0.412658, 3.88055, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.47257, 3.99211, -1.02902, 8.84658, -0.454849, 13.0528, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.273422, 2.00298, 0.51755, 3.73836, 1.186, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.816864, 2.32929, 1.75904, 4.05115, 3.31518, 5.52985, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.14057, 1.0838, 2.13457, 1.82329, 3.8155, 2.28244, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.03313, 0.55535, 3.63988, 1.06081, 5.99722, 0.84329, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.273, -0.20974, 3.99694, -0.36229, 6.35, -1.27147, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.4072, -0.93009, 4.20952, -2.25036, 6.02363, -3.96223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.50397, -2.36284, 4.35313, -5.45339, 6.03751, -8.36077, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.26063, -3.90203, 3.83606, -8.43373, 5.22497, -12.7, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.9918, -3.0465, 1.67254, -6.04296, 2.35022, -9.17223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.499573, -2.30681, 0.802683, -3.77001, 1.17755, -5.29167, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 134.12981;
        cy = 32.163585;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0, 0.3, 0, 0.6, 0, 0.896143, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 147.50842;
        cy = 113.65526;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0, 0.3, 0, 0.6, 0, 0.896143, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}