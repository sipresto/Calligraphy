namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseC : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 145.435780;
        double cy = 193.198310;

        AddRelativeBezier(newPoints, ref cx, ref cy, -9.19933, 7.12599, -18.32017, 12.41451, -29.63333, 14.94274, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -9.98155, 2.23065, -19.803312, 2.6398, -29.280555, -0.66885, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -14.194622, -4.95552, -22.106806, -18.23172, -23.489145, -32.26556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.030401, -10.46088, 0.936043, -21.06019, 5.013734, -30.69166, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.627818, -10.93086, 11.477981, -20.89973, 19.888568, -29.27522, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 17.918678, -17.843891, 49.166338, -27.336873, 64.909068, -3.18034, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints, screenWidth: 1200, screenHeight: 800, marginY: 150);
    }
}