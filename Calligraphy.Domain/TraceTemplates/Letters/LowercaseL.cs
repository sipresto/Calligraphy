namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseL : Letter
{
    public LowercaseL()
    {
        IsTall = true;
    }
    
    public override string Name { get; } = "l";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);
    
    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        double cx = 110.10385;
        double cy = 91.298499;

        AddRelativeBezier(newPoints, ref cx, ref cy, 1.93743, -11.390734, 19.35256, -67.426074, 42.96434, -42.746658, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 12.5015, 13.066773, 2.0359, 38.338551, -6.01457, 50.860547, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -12.03811, 18.724522, -28.71512, 34.188362, -44.35811, 49.073292, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -16.54357, 15.74188, -33.564764, 31.4836, -50.799996, 47.9406, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 110.22073;
        cy = 90.934653;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.13352, 5.265939, -5.45347, 23.233427, -7.96839, 34.732367, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -7.358889, 33.64687, -21.629982, 68.58838, -22.310249, 104.06944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.438732, 22.88349, 23.077629, 16.33298, 35.721379, 7.76111, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}