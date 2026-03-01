using Calligraphy.Domain;

namespace Calligraphy.Application;

public class InfinityRaceService
{
    private InfinityRaceSession _session;
    private double _dpi;
    
    public void InitializeSession(List<Circle> circles, double middle, double dpi)
    {
        _session = new InfinityRaceSession(circles, middle);
        _dpi = dpi;
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        _session.AddStroke(stroke);
    }

    public int GetScore()
    {
        // TODO: Remove stroke analysis, just for testing purposes - also remove _dpi
        foreach (var stroke in _session.Strokes)
        {
            if (StrokeAnalysis.IsPressureTooHigh(stroke))
            {
                Console.WriteLine("Druk minder hard");
            }
            if (StrokeAnalysis.IsPressureTooLow(stroke))
            {
                Console.WriteLine("Druk harder");
            }
            if (StrokeAnalysis.IsStandardDeviationOff(stroke))
            {
                Console.WriteLine("Wees meer consistent in druk");
            }
            if (StrokeAnalysis.IsSpeedTooHigh(stroke, _dpi))
            {
                Console.WriteLine("Schrijf trager");
            }
            if (StrokeAnalysis.IsSpeedTooLow(stroke, _dpi))
            {
                Console.WriteLine("Schrijf sneller");
            }
        }
        
        return _session.CalculateScore();
    }
}