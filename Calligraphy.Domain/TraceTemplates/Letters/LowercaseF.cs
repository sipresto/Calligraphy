namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseF : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 105.352740;
        double cy = 86.038218;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.24202, -11.197013, 4.09335, -27.109263, 12.46629, -35.942122, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 8.08398, -8.528032, 20.15721, -5.328012, 21.23775, 6.661566, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.0968, 23.26572, -20.57197, 41.892986, -35.46774, 56.464018, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -11.408369, 11.15966, -22.895157, 21.84283, -34.219638, 33.14154, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 105.349720;
        cy = 85.893248;

        AddRelativeBezier(newPoints, ref cx, ref cy, -6.434105, 36.657802, -16.819874, 74.232782, -24.985073, 111.818912, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.998978, 13.80494, -10.349534, 33.73794, -7.061636, 47.40539, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.561537, 10.64804, 15.582476, 9.336, 22.12328, 2.46886, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 9.099309, -9.55327, 10.296929, -23.67543, 10.297269, -36.12305, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 90.676203;
        cy = 154.547960;

        AddRelativeBezier(newPoints, ref cx, ref cy, 6.877557, 14.45839, 14.203957, 39.56235, 15.006417, 57.63966, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 90.441354;
        cy = 153.670510;

        AddRelativeBezier(newPoints, ref cx, ref cy, 7.438091, 5.78646, 14.675076, 8.4196, 23.636106, 5.99722, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints, screenWidth: 1200, screenHeight: 800, marginY: 150);
    }
}