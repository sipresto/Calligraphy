namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseK : Letter
{
    public ConnectorLowercaseK()
    {
        IsTall = true;
    }

    public override string Name { get; } = "k";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 97.385622;
        double cy = 69.527872;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0.361445, -2.79875, 2.48594, -11.6575, 3.24414, -15.5222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.18734, -6.05222, 2.57959, -12.4767, 5.14522, -17.9917, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.69258, -5.78785, 5.22153, -11.2434, 9.98693, -15.6278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.94077, -1.78561, 4.08299, -3.48142, 6.67094, -4.50664, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.10498, -0.833907, 4.61916, -1.36611, 7.05555, -1.38333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.36911, -0.01675, 4.03386, 0.25188, 5.99723, 0.971216, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.17636, 0.797389, 3.79199, 1.67621, 5.21654, 3.27463, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.26559, 1.42007, 2.06615, 2.94797, 2.82358, 4.92474, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.48424, 1.26377, 0.72618, 2.29534, 1.00853, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.30883, 1.34807, 0.50955, 2.95533, 0.67942, 4.23333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.13674, 1.02883, 0.14777, 1.61644, 0.14971, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.004, 2.44128, 0.14174, 3.23783, -0.10073, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.21364, 1.80964, -0.40587, 3.83614, -0.86261, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.82363, 3.26098, -1.5705, 6.76722, -2.97738, 9.87778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.34375, 9.60389, -10.4874, 18.265, -16.8337, 26.4583, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.82075, 2.3507, -3.89769, 4.46719, -5.77075, 6.70278, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.35326, 2.80874, -4.95222, 5.43337, -7.38139, 8.11389, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.80652, 0.889997, -1.53884, 1.58929, -2.40819, 2.46944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.39788, 1.41527, -2.42585, 2.74897, -3.87321, 4.08227, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.3484, 2.16332, -3.83158, 3.50734, -6.0454, 5.66349, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.80876, 1.76164, -4.22345, 4.01004, -5.92645, 5.78028, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.14088, 1.18592, -1.88333, 1.92572, -3.05795, 3.20276, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.80103, 3.04527, -6.18397, 6.26636, -9.32058, 8.99094, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.34006, 2.03266, -4.78208, 4.0608, -7.05556, 6.17851, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.0855, 1.94261, -6.81997, 6.58205, -8.45796, 7.97806, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.97985, 0.83509, -1.31173, 1.11279, -1.7726, 1.51536, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 97.358106;
        cy = 69.493391;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.383353, 1.97677, -2.46575, 11.3444, -3.17635, 14.5664, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.18498, 5.37286, -2.46985, 10.5838, -3.53649, 15.875, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.654988, 3.2492, -1.32964, 6.8175, -2.13572, 10.2306, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.370789, 1.56999, -0.788077, 3.40608, -1.14053, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.518217, 2.25373, -0.822225, 3.37929, -1.24289, 5.99723, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.373319, 2.32326, -0.644276, 3.8588, -1.11659, 5.99722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.281002, 1.27226, -0.439627, 2.0432, -0.751828, 3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.623659, 2.2609, -1.32423, 6.69817, -1.79846, 9.17222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.447249, 2.33328, -1.11776, 3.82023, -1.46229, 6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.189986, 1.39501, -0.591426, 2.58523, -0.972313, 3.88056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.22253, 4.15764, -1.96762, 8.16608, -2.85161, 12.3472, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.41691, 1.97191, -0.544734, 3.71779, -0.938563, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.375257, 1.83577, -0.727345, 2.71092, -1.04554, 4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.83423, 10.8094, -3.73051, 23.1009, -7.26243, 33.5139, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 80.104516;
        cy = 149.062070;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0.442577, -1.26199, 1.04329, -2.78097, 1.93674, -4.23333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.671891, -1.09222, 1.28459, -1.87939, 1.90163, -2.82223, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.676294, -1.03337, 1.39249, -2.20092, 2.17247, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.945281, -1.18051, 1.5877, -1.9248, 2.71852, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.33488, -3.68696, 7.71966, -6.57338, 11.9346, -9.15834, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.80826, -1.72229, 6.05269, -3.24557, 9.17222, -4.35582, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.52354, -0.54223, 2.72136, -0.96212, 4.23333, -1.19798, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.25105, -0.19515, 3.70443, -0.40614, 4.93889, -0.55775, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.12629, -0.13832, 1.9411, -0.27116, 3.175, -0.24688, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.16027, 0.0228, 2.02624, 0.20058, 3.175, 0.32963, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.74505, 0.19602, 3.18269, 0.27173, 4.93889, 0.84302, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.25741, 0.40903, 2.45612, 1.11686, 3.52233, 1.88557, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.36773, 0.98608, 2.16235, 2.17689, 2.71172, 3.63911, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.75397, 2.00681, 0.87845, 3.15747, 0.96333, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.0893, 1.87449, -0.27463, 3.88292, -0.97395, 5.99722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.60825, 1.83897, -1.58553, 3.40652, -2.66081, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.8551, 4.06878, -13.0818, 9.48135, -17.569, 11.35, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 77.281105;
        cy = 161.383900;

        AddRelativeBezier(newPoints, ref cx, ref cy, 1.4317, -0.18093, 2.32706, -0.32662, 4.23333, -0.1636, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.2128, 0.10372, 2.11695, -0.16736, 3.52778, -0.38707, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.06476, -0.16581, 2.3836, -0.11529, 3.52778, -0.25588, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.59944, -0.44229, 7.35115, -1.00642, 10.9361, -1.63595, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.50378, -0.43967, 11.2906, -2.91924, 16.9509, -4.76851, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 77.601840;
        cy = 161.687280;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.58122, 2.70567, 8.27013, 10.5315, 11.1226, 13.9983, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.57813, 5.56418, 8.97483, 11.237, 13.3797, 16.9333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.1356, 2.76176, 4.37698, 6.12973, 7.05201, 8.35069, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.63034, 1.35362, 3.16017, 2.31246, 5.2914, 3.13963, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.37634, 0.92229, 4.37021, 1.39356, 6.70278, 1.55376, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.38203, 0.16355, 5.29448, 0.48625, 7.76111, 0.15841, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.04976, -0.40534, 5.47454, -0.56485, 8.46667, -1.71189, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.36134, -0.90525, 5.02098, -2.32837, 7.05556, -3.62196, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.40633, -0.89416, 3.19479, -2.17911, 4.58611, -3.28253, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}