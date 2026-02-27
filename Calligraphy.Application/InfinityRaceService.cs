using Calligraphy.Domain;

namespace Calligraphy.Application;

public class InfinityRaceService
{
    private InfinityRaceSession _session;
    
    public void InitializeSession(List<Circle> circles, double middle)
    {
        _session = new InfinityRaceSession(circles, middle);
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        _session.AddStroke(stroke);
    }

    public int GetScore()
    {
        return _session.CalculateScore();
    }
}