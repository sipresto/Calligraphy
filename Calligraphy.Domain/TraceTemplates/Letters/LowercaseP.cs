namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseP : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 65.915547;
        double cy = 52.780750;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.472897, 8.079008, -3.367533, 17.625087, -5.454938, 24.694445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -13.092563, 44.340165, -19.471836, 93.768195, -30.895740, 141.111115, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.82104, 15.8351, -5.82388, 38.0268, -11.9799, 52.5639, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 49.287756;
        cy = 123.263480;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.1144, -7.67254, 2.80809, -15.0526, 6.15175, -21.8722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.713872, -7.574709, 7.844009, -14.429222, 13.054081, -21.519078, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 10.532119, -14.332092, 23.605288, -24.326508, 42.177508, -26.190262, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 16.2465, -1.63037, 35.5243, 4.44574, 38.945, 21.6038, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.94127, 9.73746, 0.62839, 20.1459, -1.58617, 30.3389, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.51273, 16.168, -10.3607, 34.1392, -9.37936, 50.4472, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.34037, 5.65619, 0.14972, 8.60303, 4.06467, 14.0911, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.1592, 8.6341, 19.3129, 7.14941, 28.2809, 3.86856, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.97248, -2.18497, 11.2363, -5.55355, 16.2278, -9.493, pointsPerCurve);

        // newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints, screenWidth: 1200, screenHeight: 800, marginY: 150);
    }
}