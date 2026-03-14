namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseS : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 113.436140;
        double cy = 73.182847;

        AddRelativeBezier(newPoints, ref cx, ref cy, -22.080243, 18.280118, -45.494511, 41.007473, -67.380557, 59.266663, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 113.346860;
        cy = 73.302438;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.15967, 3.35139, 6.16818, 15.1649, 9.17612, 22.5778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.43144, 18.3142, 12.8378, 37.5914, 11.948, 57.5028, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.38217, 8.55248, -1.96377, 17.0739, -5.04243, 24.6944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.19618, 7.91143, -7.95208, 14.5327, -14.4614, 20.6816, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.63259, 5.32071, -12.1027, 9.66976, -19.2592, 12.3213, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.28027, 1.9564, -10.1487, 2.65014, -15.875, 3.19595, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -9.48336, 0.90393, -20.0963, -0.62064, -28.575, -3.99216, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.62027, -3.03017, -13.5636, -7.90488, -18.6972, -14.5678, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}