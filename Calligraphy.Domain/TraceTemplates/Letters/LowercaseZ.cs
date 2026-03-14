namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseZ : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 22.241415;
        double cy = 117.905330;

        AddRelativeBezier(newPoints, ref cx, ref cy, 5.9904, -5.37155, 13.7454, -12.0342, 19.9725, -17.4571, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 9.40308, -8.18866, 19.4469, -17.4001, 30.7513, -22.8044, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.9246, -1.87622, 6.70703, -2.56748, 10.7788, -2.66957, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.52841, -0.08847, 7.83282, 0.916224, 11.0958, 2.29225, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.04146, 2.126, 12.6438, 7.37217, 17.7534, 10.0741, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.71721, 3.55209, 11.3109, 4.27027, 18.3874, 4.24972, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.13119, -0.0149, 8.73728, -0.380182, 13.315, -2.18363, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.68774, -1.45283, 7.07388, -3.12152, 10.7788, -4.73522, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.48123, -1.51626, 5.06931, -2.51243, 8.55965, -4.17505, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 163.742290;
        cy = 80.541557;

        AddRelativeBezier(newPoints, ref cx, ref cy, -3.73109, 4.66573, -11.1302, 15.3106, -14.9313, 20.5387, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.36301, 4.62554, -10.5587, 13.7102, -14.3051, 18.6132, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -27.3313, 35.7689, -55.1858, 71.8581, -80.4974, 109.433, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -8.35625, 12.4047, -22.5132, 33.4429, -27.9508, 42.0401, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 199.149210;
        cy = 226.878980;

        AddRelativeBezier(newPoints, ref cx, ref cy, -13.459, 13.2065, -37.8817, 34.9535, -55.5726, 43.6807, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.62142, 2.27979, -8.07886, 2.99848, -12.7023, 2.9728, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.71998, -0.0207, -6.42876, -0.3928, -9.84429, -2.21604, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.13162, -3.80697, -17.7312, -12.6694, -25.4046, -16.2088, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.48391, -2.5295, -9.56886, -3.44971, -15.2428, -3.44971, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.43658, -1e-05, -10.5076, 0.97152, -15.5603, 2.599, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.92129, 2.55145, -15.5316, 5.0085, -23.4993, 8.82766, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.71617, 2.73996, -10.4051, 4.77544, -15.2428, 7.93495, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}