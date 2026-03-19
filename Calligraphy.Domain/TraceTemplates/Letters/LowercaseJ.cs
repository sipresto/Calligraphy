namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseJ : Letter
{
    public LowercaseJ()
    {
        IsLow = true;
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
        
        double cx = 129.74613;
        double cy = 72.021769;

        AddRelativeBezier(newPoints, ref cx, ref cy, -12.17753, 45.586611, -18.64379, 89.817011, -29.931533, 135.167751, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 149.6075;
        cy = 114.22036;

        AddRelativeBezier(newPoints, ref cx, ref cy, -26.7902, 26.69134, -61.056682, 52.26495, -81.613545, 84.31389, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -6.950965, 10.8368, -15.45675, 32.28806, -4.802905, 43.51769, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 20.046376, 21.12976, 34.527533, -26.04962, 36.674786, -35.05103, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 133.67493;
        cy = 48.710259;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0, 0.117, 0, 0.235, 0, 0.352778, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}