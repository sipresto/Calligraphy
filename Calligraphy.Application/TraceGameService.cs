using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class TraceGameService : GenericGameService<TraceGameSession>
{
    public void InitializeSession(double dpi, List<StrokePoint> templatePoints, double? toleranceDistance = null)
    {
        var session = toleranceDistance.HasValue
            ? new TraceGameSession(dpi, templatePoints, toleranceDistance.Value)
            : new TraceGameSession(dpi, templatePoints);
        InitializeSession(session);
    }
}