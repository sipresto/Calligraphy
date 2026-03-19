namespace Calligraphy.Domain.TraceTemplates.Letters;

public class LowercaseW : Letter
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
        
        double cx = 14.543820;
        double cy = 126.544300;

        AddRelativeBezier(newPoints, ref cx, ref cy, 3.3132, -2.19186, 6.62735, -4.4501, 10.2306, -5.95206, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 11.0465, -4.60466, 22.0855, -0.32675, 22.0806, 12.3021, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.0068, 17.3753, -16.8863, 46.2771, -2.85763, 60.8884, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 14.1692, 14.7576, 37.7856, 0.73651, 46.6791, -12.9106, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 5.36237, -8.2285, 7.28085, -9.63011, 9.66829, -19.7556, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.9632, -12.5673, 5.87001, -28.1822, 8.74353, -41.275, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 167.787390;
        cy = 119.790890;

        AddRelativeBezier(newPoints, ref cx, ref cy, -1.61011, 7.11016, -3.75931, 17.1701, -5.50385, 25.7528, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.2633, 16.0546, -7.91098, 32.4289, -20.2529, 44.0168, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -10.0839, 9.46774, -33.1522, 16.5085, -41.5478, 0.78515, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.52588, -4.73044, -2.20989, -10.359, -2.19043, -15.8742, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.01681, -4.76508, 0.399597, -7.09447, 1.9224, -12.5079, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 167.534860;
        cy = 119.979520;

        AddRelativeBezier(newPoints, ref cx, ref cy, 5.90978, 9.77567, 15.4938, 13.9168, 25.7528, 11.2889, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        
        return ScaleAndCenter(rawPoints);
    }
}