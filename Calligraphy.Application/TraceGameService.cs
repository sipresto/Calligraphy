using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class TraceGameService : GenericGameService<TraceGameSession>
{
    public TraceGameService(IRepository repository) : base(repository)
    {
    }

    public void StartSession(string gameId, List<StrokePoint> templatePoints, double toleranceDistance,
        double requiredAccuracy)
    {
        Initialize(gameId, () => new TraceGameSession(templatePoints, toleranceDistance, requiredAccuracy));
    }
}