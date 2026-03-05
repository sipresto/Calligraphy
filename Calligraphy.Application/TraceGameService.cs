using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class TraceGameService : GenericGameService<TraceGameSession>
{
    public void InitializeSession(List<StrokePoint> templatePoints, double? toleranceDistance = null)
    {
        var session = toleranceDistance.HasValue
            ? new TraceGameSession(templatePoints, toleranceDistance.Value)
            : new TraceGameSession(templatePoints);
        InitializeSession(session);
    }
}