namespace Calligraphy.Domain.Utility;

public static class TraceEvaluator
{
    // Evaluates how well the users strokes match the template
    public static TraceEvaluationResult Evaluate(List<StrokePoint> userPoints, List<StrokePoint> templatePoints, double toleranceDistance)
    {
        if (userPoints.Count < 10)
            return new TraceEvaluationResult
            {
                AccuracyScore = 0,
                CoverageScore = 0,
                DirectionCorrect = false,
            };

        return new TraceEvaluationResult
        {
            AccuracyScore = CalculateAccuracy(userPoints, templatePoints, toleranceDistance),
            CoverageScore = CalculateCoverage(userPoints, templatePoints, toleranceDistance),
            DirectionCorrect = CheckDirectionConsistency(userPoints),
        };
    }
    
    // Calculates how much of the user strokes were in the bounds of the template (0 - 1)
    private static double CalculateAccuracy(List<StrokePoint> userPoints, List<StrokePoint> templatePoints, double toleranceDistance)
    {
        int coveredPoints = 0;

        foreach (var userPoint in userPoints)
        {
            bool isCovered = templatePoints.Any(templatePoint =>
                Distance(userPoint, templatePoint) <= toleranceDistance);

            if (isCovered)
                coveredPoints++;
        }

        return (double)coveredPoints / userPoints.Count;
    }

    // Calculates how much of the template was covered by user strokes (0 - 1)
    private static double CalculateCoverage(List<StrokePoint> userPoints, List<StrokePoint> templatePoints, double toleranceDistance)
    {
        int coveredPoints = 0;

        foreach (var templatePoint in templatePoints)
        {
            bool isCovered = userPoints.Any(userPoint =>
                Distance(templatePoint, userPoint) <= toleranceDistance);

            if (isCovered)
                coveredPoints++;
        }

        return (double)coveredPoints / templatePoints.Count;
    }

    // Checks if the user generally traced from left to right
    private static bool CheckDirectionConsistency(IReadOnlyList<StrokePoint> userPoints)
    {
        if (userPoints.Count < 2)
            return false;

        double firstX = userPoints.Take(userPoints.Count / 4).Average(p => p.X);
        double lastX = userPoints.Skip(3 * userPoints.Count / 4).Average(p => p.X);

        return lastX > firstX;
    }

    private static double Distance(StrokePoint templatePoint, StrokePoint strokePoint)
    {
        double dx = templatePoint.X - strokePoint.X;
        double dy = templatePoint.Y - strokePoint.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}

public class TraceEvaluationResult
{
    private const double MinCoverageScore = 0.90;

    public double AccuracyScore { get; set; }
    public double CoverageScore { get; set; }
    public bool DirectionCorrect { get; set; }

    public int GetScore()
    {
        if (!DirectionCorrect)
            return 0;
        
        double coverage = CoverageScore;
        
        if (coverage > MinCoverageScore)
            coverage = 1;
        else
            coverage /= MinCoverageScore;
        
        double finalScore = AccuracyScore * coverage * 100;
        return (int)Math.Round(finalScore);
    }
}