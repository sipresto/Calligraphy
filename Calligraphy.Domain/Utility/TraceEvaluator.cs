namespace Calligraphy.Domain.Utility;

public static class TraceEvaluator
{
    // Evaluates how well the users strokes match the template
    public static TraceEvaluationResult Evaluate(IReadOnlyList<StrokePoint> userPoints, IReadOnlyList<StrokePoint> templatePoints, double toleranceDistance)
    {
        if (userPoints.Count < 10)
        {
            return new TraceEvaluationResult
            {
                IsSuccessful = false,
                CoveragePercentage = 0,
                AverageDeviation = double.MaxValue,
                MaxDeviation = double.MaxValue
            };
        }

        // Calculate coverage, what percentage of template was traced
        double coverage = CalculateCoverage(userPoints, templatePoints, toleranceDistance);

        // Calculate deviation, how far off are the users strokes from the template
        var deviations = CalculateDeviations(userPoints, templatePoints);
        double avgDeviation = deviations.Average();
        double maxDeviation = deviations.Max();

        // Check direction consistency (left to right progression)
        bool directionCorrect = CheckDirectionConsistency(userPoints);

        // Determine success based on criteria
        bool isSuccessful = coverage >= 0.70 && // At least 70% coverage
                           avgDeviation <= toleranceDistance && 
                           maxDeviation <= toleranceDistance * 2 &&
                           directionCorrect;

        return new TraceEvaluationResult
        {
            IsSuccessful = isSuccessful,
            CoveragePercentage = coverage,
            AverageDeviation = avgDeviation,
            MaxDeviation = maxDeviation,
            DirectionCorrect = directionCorrect
        };
    }

    // Calculates what percentage of the template was covered by user strokes
    private static double CalculateCoverage(IReadOnlyList<StrokePoint> userPoints, IReadOnlyList<StrokePoint> templatePoints, double toleranceDistance)
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
    
    // Calculates deviation of each user point from the nearest template point
    private static List<double> CalculateDeviations(IReadOnlyList<StrokePoint> userPoints, IReadOnlyList<StrokePoint> templatePoints)
    {
        var deviations = new List<double>();

        foreach (var userPoint in userPoints)
        {
            double minDistance = templatePoints
                .Min(templatePoint => Distance(templatePoint, userPoint));
            deviations.Add(minDistance);
        }

        return deviations;
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
    public bool IsSuccessful { get; set; }
    public double CoveragePercentage { get; set; }
    public double AverageDeviation { get; set; }
    public double MaxDeviation { get; set; }
    public bool DirectionCorrect { get; set; }

    // Get a score from 0-100
    public int GetQualityScore()
    {
        if (!IsSuccessful)
            return Math.Min((int)(CoveragePercentage * 50), 30);

        // Base score on coverage and accuracy
        double coverageScore = CoveragePercentage * 60; //60 points
        double accuracyScore = Math.Max(0, 40 - (AverageDeviation / 2)); //40 points

        return (int)Math.Min(coverageScore + accuracyScore, 100);
    }
}