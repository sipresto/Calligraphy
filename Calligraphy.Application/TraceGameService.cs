using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.Utility;

namespace Calligraphy.Application;

public class TraceGameService : GenericGameService<TraceGameSession>
{
    public void InitializeSession(double dpi, List<StrokePoint> templatePoints, double? toleranceDistance = null)
    {
        var session = toleranceDistance.HasValue
            ? new TraceGameSession(templatePoints, toleranceDistance.Value)
            : new TraceGameSession(templatePoints);
        InitializeSession(session, dpi);
    }
    
    public TraceEvaluationResult GetTraceEvaluation()
    {
        return Session?.GetEvaluation();
    }
}