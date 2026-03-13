namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseD : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 162.497710;
        double cy = 52.784570;

        AddRelativeBezier(newPoints, ref cx, ref cy, -5.39578, 13.005085, -9.70598, 39.824852, -12.51072, 54.68056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.46887, 28.96652, -11.0719, 59.33249, -19.26019, 87.48888, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.22137, 7.63847, -3.76301, 16.3661, -3.72137, 23.98889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.0258, 4.72842, -0.0163, 7.75909, 1.7303, 11.63917, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.12506, 15.82849, 29.46957, 4.63813, 39.05365, -2.11417, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];
        
        cx = 134.414470;
        cy = 179.466760;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.58861, 19.00182, -9.7323, 34.1536, -24.69466, 47.05602, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -23.530661, 20.29105, -59.946461, 10.77679, -62.439418, -21.30325, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.660387, -8.49806, 1.838346, -18.99003, 5.023918, -27.16388, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 9.547641, -24.49827, 33.480665, -42.19368, 59.1796, -44.21671, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 10.7911, -0.84947, 25.95955, 5.45872, 31.75, 9.29171, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints, screenWidth: 1200, screenHeight: 800, marginY: 150);
    }
}