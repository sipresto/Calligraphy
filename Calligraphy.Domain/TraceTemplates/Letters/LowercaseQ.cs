namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseQ : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 141.828060;
        double cy = 115.499820;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.5727, 3.0223, -4.85777, 15.8232, -7.29266, 20.1083, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.31692, 7.59727, -10.8633, 14.349, -18.1073, 19.7343, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.06365, 5.25123, -19.2072, 10.7705, -28.9278, 11.5875, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -19.6669, 1.65302, -36.9896, -9.81647, -40.063, -29.2052, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.96183, -12.3766, -0.293533, -24.7529, 4.3491, -36.3361, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 11.3047, -28.2048, 37.9097, -48.8675, 67.8166, -50.8593, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 13.1236, -0.874021, 26.9696, 5.34308, 35.2778, 11.7009, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 157.208480;
        cy = 51.806447;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.11513, 9.77686, -3.77241, 16.875, -5.78407, 25.6806, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.35293, 10.2995, -4.94113, 20.5408, -9.51262, 37.2948, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 147.094380;
        cy = 94.479661;

        AddRelativeBezier(newPoints, ref cx, ref cy, -4.71664, 20.5578, -11.0198, 39.366, -15.2804, 59.6194, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -6.70522, 31.8746, -15.1354, 73.1869, -21.7613, 105.128, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}