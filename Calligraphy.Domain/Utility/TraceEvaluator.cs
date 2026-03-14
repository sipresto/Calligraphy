namespace Calligraphy.Domain.Utility;

public static class TraceEvaluator
{
    // Evaluates how well the users strokes match the template
    public static TraceEvaluationResult Evaluate(List<StrokePoint> userPoints, List<StrokePoint> templatePoints,
        double toleranceDistance, double minCoverageScore)
    {
        if (userPoints.Count < 10)
            return new TraceEvaluationResult
            {
                AccuracyScore = 0,
                CoverageScore = 0,
                DirectionCorrect = false,
                MinCoverageScore = minCoverageScore
            };

        return new TraceEvaluationResult
        {
            AccuracyScore = CalculateAccuracy(userPoints, templatePoints, toleranceDistance),
            CoverageScore = CalculateCoverage(userPoints, templatePoints, toleranceDistance),
            DirectionCorrect = CheckDirectionConsistency(userPoints, templatePoints, toleranceDistance),
            MinCoverageScore = minCoverageScore
        };
    }

    // Calculates how much of the user strokes were in the bounds of the template (0 - 1)
    private static double CalculateAccuracy(List<StrokePoint> userPoints, List<StrokePoint> templatePoints,
        double toleranceDistance)
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
    private static double CalculateCoverage(List<StrokePoint> userPoints, List<StrokePoint> templatePoints,
        double toleranceDistance)
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

    // Checks if the user progressed chronologically through the template array
    private static bool CheckDirectionConsistency(List<StrokePoint> userPoints, List<StrokePoint> templatePoints,
        double toleranceDistance)
    {
        if (userPoints.Count < 5 || templatePoints.Count < 2)
            return false;

        int forwardMoves = 0;
        int backwardMoves = 0;
        int lastMatchedIndex = -1;

        int step = Math.Max(1, userPoints.Count / 20);

        for (int i = 0; i < userPoints.Count; i += step)
        {
            var userPoint = userPoints[i];

            int closestIndex = -1;
            double minDist = double.MaxValue;

            // Find the closest template point for this user point
            for (int j = 0; j < templatePoints.Count; j++)
            {
                double dist = Distance(userPoint, templatePoints[j]);
                if (dist < minDist)
                {
                    minDist = dist;
                    closestIndex = j;
                }
            }
            
            if (minDist <= toleranceDistance * 2)
            {
                if (lastMatchedIndex != -1)
                {
                    if (closestIndex > lastMatchedIndex) forwardMoves++;
                    else if (closestIndex < lastMatchedIndex) backwardMoves++;
                }

                lastMatchedIndex = closestIndex;
            }
        }

        return forwardMoves >= backwardMoves;
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
    public double MinCoverageScore;
    public double AccuracyScore;
    public double CoverageScore;
    public bool DirectionCorrect;

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