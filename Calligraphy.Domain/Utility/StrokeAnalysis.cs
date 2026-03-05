namespace Calligraphy.Domain.Utility;

public static class StrokeAnalysis
{
    private const double MinPres = 0.15;
    private const double MaxPres = 0.6;
    private const long PresDuration = 1000;
    private const double MaxPresStdDev = 0.15;

    public static bool IsPressureTooHigh(IEnumerable<StrokePoint> stroke, double max = MaxPres,
        long durationMs = PresDuration)
    {
        return CheckPressure(stroke, p => p > max, durationMs);
    }

    public static bool IsPressureTooLow(IEnumerable<StrokePoint> stroke, double min = MinPres,
        long durationMs = PresDuration)
    {
        return CheckPressure(stroke, p => p < min, durationMs);
    }

    public static bool IsStandardDeviationOff(IEnumerable<StrokePoint> stroke, double maxStdDev = MaxPresStdDev)
    {
        var pressures = stroke
            .Where(p => p.Pressure.HasValue)
            .Select(p => p.Pressure.Value)
            .ToList();

        if (pressures.Count < 2)
            return false;

        double mean = pressures.Average();

        double variance = pressures
            .Average(p => Math.Pow(p - mean, 2));

        double stdDev = Math.Sqrt(variance);

        return stdDev > maxStdDev;
    }
    
    private static bool CheckPressure(IEnumerable<StrokePoint> stroke, Func<double, bool> predicate, long durationMs)
    {
        long? start = null;

        var points = stroke
            .Where(p => p.Pressure.HasValue && p.Timestamp.HasValue)
            .OrderBy(p => p.Timestamp)
            .ToList();

        if (points.Count < 2) 
            return false;

        foreach (var point in points)
        {
            if (predicate(point.Pressure!.Value))
            {
                start ??= point.Timestamp;

                if (point.Timestamp - start >= durationMs)
                    return true;
            }
            else
            {
                start = null;
            }
        }

        return false;
    }
}