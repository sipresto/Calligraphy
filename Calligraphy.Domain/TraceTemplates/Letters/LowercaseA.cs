namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseA : Letter
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

        double cx = 159.549010;
        double cy = 113.033350;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.226, 12.4183, -5.14726, 24.3204, -8.34339, 36.3361, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.3286, 4.99481, -4.12237, 12.8568, -6.21545, 16.5805, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.76022, 8.46874, -11.2981, 17.6801, -17.8285, 24.7999, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -8.96149, 9.77036, -17.5899, 17.1723, -29.7015, 22.1086, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -8.97648, 3.65848, -19.4243, 5.54109, -29.6333, 4.80419, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -19.6448, -1.41803, -37.3811, -9.7574, -44.7914, -29.1349, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -4.24368, -11.0971, -4.95904, -21.8112, -3.87551, -34.5722, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.03305, -23.9438, 12.0363, -44.4027, 28.0444, -62.0889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 17.6803, -19.5338, 40.4915, -33.6214, 66.4836, -36.2472, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 23.3308, -2.35696, 48.6385, 10.6986, 55.5199, 15.3238, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 172.230790;
        cy = 56.363704;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.90138, 11.6198, -10.56, 49.3471, -12.7274, 56.9129, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 150.442600;
        cy = 151.563680;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.92961, 7.84908, -7.09789, 31.8238, -5.43339, 42.6861, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.26043, 8.22538, 3.84929, 18.1574, 13.9001, 21.4418, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.39126, 1.10818, 4.97608, 1.3572, 8.81943, 1.6937, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 15.8709, 1.3896, 28.4559, -5.81474, 41.6278, -16.0799, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}