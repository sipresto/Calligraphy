namespace Calligraphy.Domain.Utility;

public static class StrokeAnalysis
{
    private const double MinPres = 0.15;
    private const double MaxPres = 0.6;
    private const long PresDuration = 1000;
    private const double MaxPresStdDev = 0.15;
    
    private const double MinSpeed = 20; // mm per second
    private const double MaxSpeed = 200; // mm per second?
    private const long SpeedDuration = 2000;
    private const long SpeedWindowDuration = 500;

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

    public static bool IsSpeedTooHigh(IEnumerable<StrokePoint> stroke, double dpi, double maxNormalizedSpeed = MaxSpeed, long durationMs = SpeedDuration)
    {
        return CheckNormalizedSpeed(stroke, dpi, speed => speed > maxNormalizedSpeed, durationMs);
    }
    
    public static bool IsSpeedTooLow(IEnumerable<StrokePoint> stroke, double dpi, double minNormalizedSpeed = MinSpeed, long durationMs = SpeedDuration)
    {
        return CheckNormalizedSpeed(stroke, dpi, speed => speed < minNormalizedSpeed, durationMs);
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
    
    private static bool CheckNormalizedSpeed(IEnumerable<StrokePoint> stroke, double dpi, Func<double, bool> predicate, long durationMs, long sampleWindowMs = SpeedWindowDuration)
    {
        long? start = null;

        var points = stroke
            .Where(p => p.Timestamp.HasValue)
            .OrderBy(p => p.Timestamp)
            .ToList();

        if (points.Count < 2) 
            return false;

        for (int i = 0; i < points.Count; i++)
        {
            var windowStartTime = points[i].Timestamp!.Value;

            var windowPoints = points
                .Skip(i)
                .TakeWhile(p => p.Timestamp!.Value - windowStartTime <= sampleWindowMs)
                .ToList();

            if (windowPoints.Count < 2)
                continue;

            double totalDistanceMm = 0;

            for (int j = 1; j < windowPoints.Count; j++)
            {
                double distancePx = Distance(windowPoints[j - 1], windowPoints[j]);
                double distanceMm = distancePx * 25.4 / dpi;

                totalDistanceMm += distanceMm;
            }

            long totalTimeMs = windowPoints.Last().Timestamp!.Value -
                        windowPoints.First().Timestamp!.Value;

            if (totalTimeMs <= 0)
                continue;

            double speedMmPerSec = totalDistanceMm / totalTimeMs * 1000;
            if (predicate(speedMmPerSec))
            {
                start ??= windowPoints.Last().Timestamp;

                if (windowPoints.Last().Timestamp - start >= durationMs)
                    return true;
            }
            else
            {
                start = null;
            }

            i += windowPoints.Count - 1;
        }

        return false;
    }

    private static double Distance(StrokePoint a, StrokePoint b)
    {
        double dx = a.X - b.X;
        double dy = a.Y - b.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}