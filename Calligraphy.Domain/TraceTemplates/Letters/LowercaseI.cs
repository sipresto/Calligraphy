namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseI : Letter
{
    public override List<StrokePoint> GetTemplatePoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;
        
        
        
        return ScaleAndCenter(rawPoints, screenWidth: 1200, screenHeight: 800, marginY: 150);
    }
}