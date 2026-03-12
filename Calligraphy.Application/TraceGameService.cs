using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class TraceGameService : GenericGameService<TraceGameSession>
{
    public TraceGameService(IRepository repository) : base(repository)
    {
    }

    public void InitializeSession(string gameId, List<StrokePoint> templatePoints, double toleranceDistance, double requiredAccuracy)
    {
        var session = new TraceGameSession(templatePoints, toleranceDistance, requiredAccuracy);
        InitializeSession(session, gameId);
    }
}