using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class InfinityRaceService : GenericGameService<InfinityRaceSession>
{
    public InfinityRaceService(IRepository repository) : base(repository)
    {
    }

    public void InitializeSession(string gameId, List<RaceCircle> circles)
    {
        var session = new InfinityRaceSession(circles);
        InitializeSession(session, gameId);
    }
}