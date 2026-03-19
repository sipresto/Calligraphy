namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseH : Letter
{
    public LowercaseH()
    {
        IsTall = true;
    }
    
    public override string Name { get; } = "h";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);
    
    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 91.969589;
        double cy = 106.698510;

        AddRelativeBezier(newPoints, ref cx, ref cy, 3.541128, -15.346735, 5.724101, -34.232856, 17.159981, -46.048048, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 13.38384, -13.827752, 30.03145, -3.141561, 29.64519, 14.298051, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.69703, 31.471307, -31.65058, 56.996007, -52.048736, 76.679457, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -15.214962, 14.68188, -30.928199, 29.38152, -46.261991, 44.32332, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 92.091089;
        cy = 106.076240;

        AddRelativeBezier(newPoints, ref cx, ref cy, -2.903857, 18.60801, -9.150107, 38.25204, -11.856064, 56.0927, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.493313, 9.8456, -3.708023, 18.75098, -6.216112, 28.2273, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.814196, 14.41114, -6.38068, 36.31663, -11.644747, 50.30248, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 71.688451;
        cy = 200.795860;

        AddRelativeBezier(newPoints, ref cx, ref cy, 3.853996, -19.23313, 20.76204, -45.26055, 47.625009, -42.89819, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 35.90931, 3.15792, 10.72954, 49.21366, 12.08707, 70.41486, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.27221, 19.86873, 22.71594, 13.00332, 33.06848, 5.29167, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}