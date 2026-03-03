using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class InfinityRaceService : GenericGameService<InfinityRaceSession>
{
    public void InitializeSession(List<RaceCircle> circles)
    {
        var session = new InfinityRaceSession(circles);
        InitializeSession(session);
    }
}