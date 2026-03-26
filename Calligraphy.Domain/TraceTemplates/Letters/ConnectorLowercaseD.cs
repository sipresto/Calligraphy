namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseD : Letter
{
    public ConnectorLowercaseD()
    {
        IsTall = true;
    }

    public override string Name { get; } = "d";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 37.851275;
        double cy = 135.135080;

        AddRelativeBezier(newPoints, ref cx, ref cy, 1.9312, -1.9152, 3.29511, -2.9461, 5.64445, -5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.89675, -1.8937, 4.33274, -4.15294, 6.35, -5.85268, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.49449, -1.25924, 2.60444, -2.26652, 4.23333, -3.67232, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.80326, -4.14539, 9.57647, -8.94841, 14.8167, -12.6491, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.01595, -3.54232, 10.5239, -6.70859, 16.5806, -8.78977, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.62389, -0.557998, 3.03794, -0.796399, 4.58611, -1.38661, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.22195, -0.847085, 4.72199, -1.16705, 7.05556, -1.63431, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.37438, -0.275198, 2.20719, -0.263808, 3.52778, -0.437721, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.9747, -0.391729, 9.3894, -0.280452, 12.3472, 0.103719, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.73165, 0.354802, 5.29808, 0.766922, 8.11389, 1.77668, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.57541, 0.923544, 4.22367, 1.5254, 6.35, 2.90878, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.56779, 2.32118, 6.44391, 4.07912, 8.81945, 5.64445, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 157.354750;
        cy = 9.836067;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.82975, 2.19931, -1.11535, 4.43881, -1.76389, 6.70278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.63592, 2.21998, -1.24023, 4.75897, -1.67188, 7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.45837, 2.43874, -0.95231, 4.36522, -1.50176, 7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.25451, 1.24622, -0.3705, 2.2394, -0.66717, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.72891, 3.16559, -1.42764, 6.49192, -2.08236, 9.525, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.30317, 1.40444, -0.53847, 2.65352, -0.97559, 4.23333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.84448, 3.05207, -1.15163, 5.89579, -2.01432, 9.17222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.34994, 1.32903, -0.50966, 2.14548, -0.81499, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.41965, 1.89999, -0.63816, 3.57803, -0.98646, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.6256, 3.07791, -1.48714, 6.58199, -2.20623, 9.525, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.43323, 1.77306, -0.74923, 3.27747, -1.18518, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.39296, 1.81557, -0.46455, 2.96229, -0.87949, 4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.85953, 3.36355, -1.2982, 5.62563, -1.91469, 8.81945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.31239, 1.6184, -0.92899, 3.75201, -1.31203, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.33977, 1.36575, -0.41732, 2.35511, -0.85146, 3.88056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.29614, 1.04057, -0.54968, 1.75082, -0.66418, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.18934, 1.77176, -0.65485, 3.56884, -1.04391, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.56525, 2.50302, -1.07966, 4.91775, -1.79247, 7.40833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.52152, 5.31626, -2.42492, 11.183, -3.54247, 16.5806, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.39566, 1.91095, -0.92334, 4.00608, -1.25161, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.23792, 1.18751, -0.39066, 2.01151, -0.62961, 3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.68121, 3.3169, -1.40925, 7.08262, -2.30148, 10.2305, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.76303, 2.69204, -1.0725, 3.87694, -2.51873, 7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.04552, 2.29792, -2.01824, 5.30166, -3.18915, 7.40834, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.35725, 2.44192, -2.47468, 4.20626, -4.08171, 6.70277, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.04257, 1.61964, -2.06504, 3.37541, -3.1682, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.18068, 1.67339, -2.43185, 3.01868, -3.75916, 4.58476, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.14786, 2.53423, -5.32884, 5.79228, -8.02705, 7.93423, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.20189, 2.54179, -6.59722, 4.91929, -10.5833, 6.50815, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.02874, 1.20725, -6.22071, 1.91603, -9.17222, 2.78222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.17075, 0.34356, -1.95367, 0.39836, -3.175, 0.56508, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.08522, 0.42116, -7.38286, 0.43057, -10.5833, 0.17314, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.75246, -0.22142, -4.90381, -0.8312, -7.76111, -1.5132, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.76392, -1.13707, -9.66894, -4.11146, -12.9926, -7.64271, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.97208, -3.15766, -4.79296, -6.4889, -6.42786, -10.5694, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.38548, -3.45803, -2.06516, -6.25684, -2.39214, -9.525, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.379111, -3.78919, -0.417104, -11.1318, 0.04138, -14.8167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.152332, -1.22433, 0.287961, -1.91358, 0.535427, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.560339, -2.85625, 1.4862, -5.97422, 2.27563, -8.81945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.619848, -2.23404, 1.29637, -4.22091, 2.23018, -6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.844925, -1.92645, 1.5304, -2.86016, 2.31402, -4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.01003, -2.22463, 2.09247, -4.85589, 3.55255, -7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.69673, -4.06275, 6.67881, -9.28158, 10.0601, -12.6651, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 123.333440;
        cy = 160.549900;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.31694, 5.4297, -2.27972, 9.33135, -3.08473, 14.0465, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.18189, 1.15554, -0.15481, 2.39162, -0.15489, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.00017, 2.7739, -0.23831, 4.16379, 0.20334, 7.40833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.39874, 2.92933, 0.51483, 4.60226, 1.27202, 7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.74437, 2.41183, 1.66651, 3.81562, 3.03481, 5.639, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.4366, 1.91442, 3.08008, 2.65856, 5.01484, 3.37152, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.81317, 0.66818, 3.41999, 0.88918, 5.29166, 1.11905, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.00351, 0.6145, 9.02643, -0.61008, 13.4056, -2.08781, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.12788, -1.73041, 10.3286, -4.62022, 14.4639, -8.39454, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}