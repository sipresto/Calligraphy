namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseG : Letter
{
    public LowercaseG()
    {
        IsLow = true;
    }
    
    public override string Name { get; } = "g";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);
    
    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 129.062260;
        double cy = 102.159760;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.51065, 2.17675, -2.11053, 9.25472, -4.59382, 13.75833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.10668, 12.88846, -19.42676, 25.12049, -35.270071, 26.7822, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -14.013163, 1.46976, -27.387524, -5.66015, -30.626038, -19.37387, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.286122, -9.68074, -0.965111, -20.163, 2.778072, -29.280553, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 7.892993, -19.22557, 26.055946, -35.364594, 46.897967, -37.503309, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 9.11746, -0.93558, 25.42002, 4.896579, 29.63333, 7.164421, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 137.916510;
        cy = 60.945113;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.65304, 14.066497, -7.30218, 34.86231, -10.94285, 49.036107, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.16625, 20.11317, -8.85394, 40.83189, -13.04637, 61.73612, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.76812, 18.78862, -6.71056, 43.63312, -15.902738, 60.325, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.38495, 13.41016, -30.16348, 25.32877, -35.910965, 4.93888, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -5.386778, -19.11024, 6.449633, -36.96361, 16.536243, -52.56388, pointsPerCurve);
        
        rawPoints.AddRange(newPoints);
        newPoints = [];
        
        cx = 164.335690;
        cy = 98.734793;

        AddRelativeBezier(newPoints, ref cx, ref cy, -27.98787, 26.725187, -61.9316, 55.514377, -86.430552, 86.783337, pointsPerCurve);
        
        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}