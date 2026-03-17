using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class InfinityRaceService : GenericGameService<InfinityRaceSession>
{
    public InfinityRaceService(IRepository repository) : base(repository)
    {
    }

    public void StartSession(string gameId, List<RaceCircle> circles)
    {
        Initialize(gameId, () => new InfinityRaceSession(circles));
    }
}