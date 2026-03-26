namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseQ : Letter
{
    public ConnectorLowercaseQ()
    {
        IsLow = true;
    }
    
    public override string Name { get; } = "q";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 19.512056;
        double cy = 110.760490;

        AddRelativeBezier(newPoints, ref cx, ref cy, 7.24279, -6.66475, 11.6416, -10.7916, 20.1326, -15.7736, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.89288, -2.28413, 8.11826, -4.5308, 10.559, -5.91378, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.77697, -1.00686, 7.31245, -3.9993, 9.525, -5.23261, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.12435, -0.626728, 2.0591, -1.30533, 3.175, -1.83385, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.61356, -1.23787, 5.74145, -2.40896, 8.46667, -3.50872, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.5631, -0.630797, 3.72268, -1.33198, 5.29167, -1.80525, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.01719, -0.608447, 3.88834, -1.36622, 5.99722, -2.22038, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.57211, -2.25686, 11.0857, -4.32997, 16.9333, -5.23504, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.52563, -0.545682, 7.43122, -0.890773, 10.9361, -0.804925, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.04678, 0.02564, 1.82756, 0.191483, 2.82223, 0.28773, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.30721, 0.416814, 8.12755, 0.775922, 12.3472, 2.42696, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.85181, 1.5071, 9.52442, 4.63948, 12.9079, 7.03925, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 87.055693;
        cy = 72.740611;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.41726, 0.643027, -9.03522, 4.3736, -10.3013, 5.11503, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.35522, 0.793577, -1.98301, 1.39856, -3.52778, 2.34695, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.93691, 1.80306, -4.25043, 2.437, -7.05556, 5.11909, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.87178, 2.74582, -4.79514, 4.35603, -7.43091, 7.65091, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.87463, 3.59346, -4.56894, 6.20423, -6.78636, 9.62132, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.32975, 2.04918, -2.14995, 3.87671, -3.15894, 5.99722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.991563, 2.08388, -1.89763, 4.20614, -2.78112, 6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.874656, 2.12243, -1.88023, 5.31857, -2.46999, 7.40833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.288559, 1.02249, -0.49619, 1.70145, -0.724062, 2.82223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.563252, 2.77028, -1.01555, 5.65635, -1.28317, 8.46666, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.188619, 1.98068, -0.468296, 2.99753, -0.298076, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.119146, 1.60581, 0.172341, 2.13776, 0.269762, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.127748, 1.8227, 0.510918, 4.37077, 0.877315, 6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.380877, 2.05745, 0.814367, 3.56194, 1.63268, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.4557, 3.70459, 3.20545, 6.65479, 5.6782, 9.52473, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.88883, 3.35286, 6.76243, 5.7446, 10.8302, 7.33647, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.95703, 0.76584, 3.69294, 1.15475, 5.64445, 1.55128, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.79293, 0.36432, 3.89875, 0.60858, 5.64445, 0.84059, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.64805, 0.21904, 2.27434, 0.15285, 4.23333, 0.14971, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.76128, -0.003, 2.36963, -0.11727, 3.88056, -0.29807, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.31296, -0.15712, 2.8836, -0.28579, 4.23333, -0.52073, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.75607, -0.4797, 4.94765, -1.24234, 7.76111, -2.40521, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.71122, -2.77386, 12.6752, -7.3261, 17.9601, -12.0902, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.22912, -1.10801, 2.08626, -1.9306, 3.24741, -3.38814, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.64312, -2.06252, 3.50575, -4.29225, 4.94569, -6.69761, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.20319, -2.00989, 1.96233, -3.11914, 3.04625, -4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.51869, -4.05821, 4.14108, -7.42261, 5.33836, -11.9962, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.4291, -5.01357, 2.69699, -11.8048, 3.9569, -17.2844, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.21106, -9.61628, 3.99011, -19.7082, 6.27242, -29.2806, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.45084, -1.89086, 0.93733, -3.34064, 1.49659, -5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.35705, -1.24551, 0.64921, -2.05832, 0.95488, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.47878, -1.74905, 0.87113, -4.12072, 1.46474, -5.99722, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 126.358190;
        cy = 132.061820;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.6127, 2.45081, -2.74637, 10.8961, -3.39126, 13.2676, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.71903, 2.64422, -1.36284, 5.07978, -1.97077, 7.76111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.03764, 4.5766, -2.07372, 10.3394, -3.30702, 14.8167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.66025, 2.3969, -0.79162, 3.9067, -1.22438, 6.70278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.44214, 9.3178, -4.15243, 18.3829, -5.87854, 27.5167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.33814, 1.78932, -0.81789, 3.53458, -1.19988, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.29801, 1.3708, -0.55828, 2.51225, -0.85363, 3.88055, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.35873, 1.66196, -0.63633, 2.89005, -1.02622, 4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.54484, 2.37017, -1.0156, 5.05775, -1.58994, 7.40834, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.27574, 1.12848, -0.4007, 2.0187, -0.66092, 3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.82912, 3.68416, -1.672, 7.57514, -2.52307, 11.2889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.76147, 3.32271, -1.40305, 6.52006, -2.19888, 9.87778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.771874, 3.25669, -1.41033, 5.80891, -2.31816, 9.22025, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}