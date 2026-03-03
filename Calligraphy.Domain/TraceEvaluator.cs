using System;
using System.Collections.Generic;
using System.Linq;

namespace Calligraphy.Domain;

public class TraceEvaluator
{
    private readonly List<StrokePoint> _templatePoints;
    private readonly double _toleranceDistance;

    public TraceEvaluator(List<StrokePoint> templatePoints, double toleranceDistance = 30.0)
    {
        _templatePoints = templatePoints;
        _toleranceDistance = toleranceDistance;
    }

    // Evaluates how well the users strokes match the template
    public TraceEvaluationResult Evaluate(List<List<StrokePoint>> userStrokes)
    {
        var userPoints = userStrokes.SelectMany(s => s).ToList();

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
        double coverage = CalculateCoverage(userPoints);

        // Calculate deviation, how far off are the users strokes from the template
        var deviations = CalculateDeviations(userPoints);
        double avgDeviation = deviations.Average();
        double maxDeviation = deviations.Max();

        // Check direction consistency (left to right progression)
        bool directionCorrect = CheckDirectionConsistency(userPoints);

        // Determine success based on criteria
        bool isSuccessful = coverage >= 0.70 && // At least 70% coverage
                           avgDeviation <= _toleranceDistance && 
                           maxDeviation <= _toleranceDistance * 2 &&
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
    private double CalculateCoverage(List<StrokePoint> userPoints)
    {
        int coveredPoints = 0;

        foreach (var templatePoint in _templatePoints)
        {
            bool isCovered = userPoints.Any(userPoint =>
                Distance(templatePoint, userPoint) <= _toleranceDistance);

            if (isCovered)
                coveredPoints++;
        }

        return (double)coveredPoints / _templatePoints.Count;
    }

    
    // Calculates deviation of each user point from the nearest template point
    private List<double> CalculateDeviations(List<StrokePoint> userPoints)
    {
        var deviations = new List<double>();

        foreach (var userPoint in userPoints)
        {
            double minDistance = _templatePoints
                .Min(templatePoint => Distance(templatePoint, userPoint));
            deviations.Add(minDistance);
        }

        return deviations;
    }

    // Checks if the user generally traced from left to right
    private bool CheckDirectionConsistency(List<StrokePoint> userPoints)
    {
        if (userPoints.Count < 2)
            return false;

        double firstX = userPoints.Take(userPoints.Count / 4).Average(p => p.X);
        double lastX = userPoints.Skip(3 * userPoints.Count / 4).Average(p => p.X);

        return lastX > firstX;
    }

    private double Distance(StrokePoint templatePoint, StrokePoint strokePoint)
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