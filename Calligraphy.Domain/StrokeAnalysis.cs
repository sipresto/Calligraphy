namespace Calligraphy.Domain;

public static class StrokeAnalysis
{
    private const double MinPres = 0.1;
    private const double MaxPres = 0.6;
    private const long PresDuration = 1000;
    private const double MaxStdDev = 0.15;

    public static bool IsPressureTooHigh(IEnumerable<StrokePoint> stroke, double max = MaxPres, long durationMs = PresDuration)
    {
        long? start = null;

        foreach (var point in stroke)
        {
            if (point.Pressure is null || point.Timestamp is null)
                continue;

            if (point.Pressure > max)
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

    public static bool IsPressureTooLow(IEnumerable<StrokePoint> stroke, double min = MinPres, long durationMs = PresDuration)
    {
        long? start = null;

        foreach (var point in stroke)
        {
            if (point.Pressure is null || point.Timestamp is null)
                continue;

            if (point.Pressure < min)
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

    public static bool IsStandardDeviationOff(IEnumerable<StrokePoint> stroke, double maxStdDev = MaxStdDev)
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
}