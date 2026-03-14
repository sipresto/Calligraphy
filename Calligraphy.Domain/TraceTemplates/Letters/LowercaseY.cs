namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseY : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 46.760538;
        double cy = 36.574956;

        AddRelativeBezier(newPoints, ref cx, ref cy, -7.874665, 21.631195, -22.099878, 65.611904, -14.040029, 86.783314, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 9.87623, 25.9426, 47.8613, 12.9612, 61.683, 0.16635, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.83937, -4.47981, 9.60292, -9.95594, 12.9729, -16.3941, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.87343, -7.39991, 5.76205, -15.5303, 7.84584, -24.3417, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.45524, -14.6106, 5.33351, -31.2093, 10.9133, -45.1556, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 113.593430;
        cy = 89.605814;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.46992, 13.2846, -10.9904, 42.2457, -13.2119, 57.3948, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.50543, 10.2662, -5.95343, 24.1941, -8.2862, 35.3199, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.72122, 8.20904, -5.49706, 22.9188, -6.27932, 27.694, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 152.155970;
        cy = 92.765294;

        AddRelativeBezier(newPoints, ref cx, ref cy, -11.7041, 10.871, -23.8524, 22.114, -35.6426, 33.0054, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -25.5195, 23.5739, -54.9521, 48.0317, -74.6478, 78.8252, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -8.85719, 13.8479, -20.4867, 46.928, -4.28907, 58.5589, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 9.88594, 7.09873, 23.6326, 1.445, 30.8855, -7.40949, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.60952, -9.28986, 15.7844, -38.9059, 17.3719, -45.8577, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}