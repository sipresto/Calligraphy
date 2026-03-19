namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseO : Letter
{
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);
    
    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 26.036682;
        double cy = 158.737180;

        AddRelativeBezier(newPoints, ref cx, ref cy, 4.93593, -25.9476, 14.409, -41.3738, 22.4417, -50.504, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 10.621, -12.0722, 19.3652, -19.0613, 31.9193, -25.4317, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 6.07803, -3.08422, 15.3864, -6.81616, 21.4599, -7.46861, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 9.49142, -1.01963, 15.1903, -0.450739, 22.9764, 2.28328, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.18768, 1.47048, 8.81345, 4.02182, 12.2541, 6.94648, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.06835, 2.60821, 8.52865, 7.49472, 11.6632, 11.951, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 148.733180;
        cy = 96.432741;

        AddRelativeBezier(newPoints, ref cx, ref cy, 4.10308, 10.5599, 6.61748, 20.0619, 7.44275, 31.4043, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.20734, 16.5938, -1.91172, 33.9089, -8.55825, 49.187, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.76118, 13.243, -13.2188, 25.7284, -24.1043, 35.8851, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.24193, 6.7571, -15.8429, 12.5532, -24.8992, 16.0453, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -8.8788, 3.42371, -18.3673, 5.21653, -28.2825, 4.41397, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -6.271777, -0.507660, -10.973878, -1.079460, -16.600614, -3.179620, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.208496, -1.944050, -10.099530, -4.807190, -14.136573, -8.797010, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.764907, -4.709150, -7.937907, -10.166010, -10.213564, -16.085260, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -6.062782, -15.770030, -5.036982, -29.304080, -3.317553, -46.727660, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 148.570940;
        cy = 96.288608;

        AddRelativeBezier(newPoints, ref cx, ref cy, 2.47316, 2.29717, 5.79864, 3.06984, 8.89127, 3.45764, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.46107, 0.559407, 11.5584, 0.647937, 14.6037, 0.400367, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 8.01193, -0.651346, 14.2592, -1.77002, 22.849, -4.64264, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}