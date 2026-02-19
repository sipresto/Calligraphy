using Calligraphy.Domain;

namespace Calligraphy.Application;

public class InfinityRaceService
{
    private readonly InfinityRaceSession _session;

    public InfinityRaceService(InfinityRaceSession session)
    {
        _session = session;
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        _session.AddStroke(stroke);
    }
}