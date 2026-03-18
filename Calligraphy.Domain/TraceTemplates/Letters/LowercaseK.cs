namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseK : Letter
{
    public LowercaseK()
    {
        IsTall = true;
    }
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);
    
    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 105.78833;
        double cy = 101.89518;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.28335, -14.998376, 7.09036, -39.299542, 19.10558, -51.080972, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.82812, -6.695263, 20.13221, -9.687909, 26.95379, -1.692941, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 12.30165, 14.41766, 1.80666, 39.370487, -7.16553, 53.126693, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -8.33805, 12.78392, -18.64749, 23.99186, -29.16464, 34.97603, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.88466, 4.05716, -7.93195, 7.14085, -11.96342, 10.79898, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.736541, 4.29791, -8.860773, 7.56018, -13.58275, 13.1383, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -12.153026, 14.35651, -27.054776, 26.30249, -40.627473, 39.86446, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 105.91106;
        cy = 101.21048;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.13459, 11.79025, -6.684715, 30.01743, -9.235803, 42.55752, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.496054, 22.10069, -7.717191, 45.11405, -13.924485, 66.72154, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.663756, 12.75347, -4.750495, 26.33586, -9.028265, 39.67227, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 90.241703;
        cy = 178.99336;

        AddRelativeBezier(newPoints, ref cx, ref cy, 8.468454, -6.42693, 33.872257, -28.18071, 52.524607, -16.41859, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 10.46888, 6.60164, 3.19147, 21.08378, -4.19484, 26.92852, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -14.00116, 11.07902, -37.77731, 14.18452, -53.974211, 14.18452, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 84.317706;
        cy = 203.95694;

        AddRelativeBezier(newPoints, ref cx, ref cy, 7.808739, 9.08498, 21.080994, 28.19229, 30.018274, 38.48003, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 12.30791, 14.1677, 32.47158, 10.26906, 45.95818, 0.002, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}