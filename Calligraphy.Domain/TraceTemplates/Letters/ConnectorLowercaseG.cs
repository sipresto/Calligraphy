namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseG : Letter
{
    public ConnectorLowercaseG()
    {
        IsLow = true;
    }

    public override string Name { get; } = "g";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 13.927651;
        double cy = 109.468700;

        AddRelativeBezier(newPoints, ref cx, ref cy, 3.29059, -2.50718, 6.09616, -5.80536, 8.92016, -8.78787, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.3144, -1.38818, 2.75278, -2.5345, 4.13262, -3.91213, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.69936, -4.69182, 8.27104, -8.55628, 13.1127, -13.2025, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.61842, -1.55309, 2.6492, -2.56647, 4.17344, -4.08335, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.8838, -2.86991, 5.66926, -5.31784, 8.46667, -8.11416, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.33992, -3.33864, 7.32114, -6.44367, 11.2889, -8.96509, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.12848, -1.35261, 4.46019, -2.6431, 6.70278, -3.69273, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.12356, -1.93001, 8.11253, -2.84451, 12.3472, -3.77303, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.90086, -0.636051, 6.51963, -1.0295, 9.525, -0.823701, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.22238, 0.152187, 4.96928, 0.690591, 7.05556, 1.02677, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.7871, 0.449111, 5.15482, 1.13647, 7.76111, 2.42589, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.69614, 1.33386, 4.96652, 2.63414, 7.81791, 3.95251, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 116.745190;
        cy = 55.183508;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.54344, 2.59954, -1.35931, 5.58222, -1.9136, 8.11389, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.57049, 2.60563, -1.25339, 5.05118, -1.99499, 7.76111, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.0045, 3.67058, -1.5809, 7.486, -2.48224, 11.2889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.26933, 1.13634, -0.45445, 2.07789, -0.70665, 3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.57084, 2.48326, -1.06582, 4.67624, -1.64765, 7.40833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.0798, 5.07035, -2.35805, 10.6065, -3.65164, 15.1694, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.63342, 2.2343, -1.70624, 4.69814, -2.92239, 7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.94815, 1.83793, -1.87881, 3.05761, -2.90008, 4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.13011, 4.68474, -6.82023, 9.26471, -11.7671, 12.749, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.05689, 2.85741, -7.89722, 5.40849, -12.6997, 7.02289, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.72046, 0.57835, -3.51834, 0.83266, -5.29167, 1.08773, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.52206, 0.50662, -7.36176, 0.59187, -10.9361, 0.10371, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.84584, -0.38867, -5.43413, -1.00552, -8.11389, -2.02493, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.29435, -0.87278, -3.81433, -1.82867, -5.61287, -3.34214, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.69761, -1.42855, -4.23142, -3.98, -5.32841, -6.07126, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.729467, -1.39061, -1.19121, -2.74065, -1.83494, -4.23333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.21923, -2.82715, -1.41347, -5.7689, -1.78811, -8.81945, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.610708, -4.97264, 0.303588, -9.95556, 1.06188, -14.8167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.194464, -1.24665, 0.411764, -2.3228, 0.752915, -3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.681924, -2.40865, 1.60469, -4.65887, 2.5013, -7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.29991, -3.47474, 3.12649, -6.70346, 5.10656, -9.87778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.05321, -3.29157, 4.91354, -6.38579, 7.87391, -9.17222, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 104.010570;
        cy = 109.605280;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.60528, 11.4806, -1.92577, 10.9494, -4.63569, 25.2601, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.44708, 7.73858, -4.65187, 21.9872, -6.41908, 30.0288, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.06735, 9.40748, -4.78969, 22.4314, -6.66291, 31.6475, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.74734, 8.59681, -3.76632, 16.6335, -6.49838, 24.8566, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.61848, 7.88129, -5.9627, 15.6308, -11.9849, 21.4879, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.18376, 2.12383, -4.94312, 4.12673, -7.74722, 4.84688, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.79649, 0.71817, -4.8254, 1.10017, -8.11389, 0.80626, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.52203, -0.13604, -2.42306, -0.35825, -3.88056, -0.68786, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.90475, -0.43074, -3.49025, -1.41679, -4.93344, -2.8312, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.70132, -1.6674, -2.70661, -3.53002, -3.51825, -5.6303, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.999143, -2.58548, -1.17756, -5.27233, -1.52653, -8.11389, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.118156, -0.96204, -0.23895, -1.80615, -0.250975, -2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.03995, -3.37647, 0.323354, -6.99882, 1.09263, -10.2306, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.259384, -1.08968, 0.301285, -2.05209, 0.467931, -3.175, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.187015, -1.26017, 0.382987, -2.3125, 0.858797, -3.52777, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.805625, -2.0577, 1.59838, -4.96663, 2.3573, -7.05556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.3362, -6.43049, 5.19109, -10.6984, 8.62754, -16.5806, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 124.512310;
        cy = 130.155610;

        AddRelativeBezier(newPoints, ref cx, ref cy, -3.96639, 2.4363, -11.624, 7.67338, -15.875, 10.5733, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.26574, 0.86344, -3.6763, 2.44259, -4.93889, 3.08899, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.36529, 0.69898, -2.73208, 1.35526, -4.23333, 2.2808, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.42562, 0.87892, -2.59056, 1.68024, -3.88056, 2.72587, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.63112, 1.32213, -3.43119, 2.61105, -5.29167, 3.62958, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.31107, 1.26521, -4.40442, 2.4186, -6.70278, 3.67287, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.14537, 1.71648, -4.15857, 3.08724, -6.70278, 4.76931, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.25019, 0.82652, -2.14806, 1.48186, -3.175, 2.25331, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.68339, 1.2646, -4.23437, 3.54956, -5.98334, 5.03688, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.21596, 1.03402, -2.23566, 2.18436, -3.39195, 3.33097, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.9509, 1.93458, -4.12893, 4.09461, -5.73944, 6.26317, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.03999, 1.40032, -1.6259, 2.26106, -2.67768, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.09134, 1.31436, -3.88241, 5.12955, -4.76422, 6.71154, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}