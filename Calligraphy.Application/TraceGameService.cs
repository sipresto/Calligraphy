using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class TraceGameService(FeedbackMessageProvider feedbackMessageProvider)
    : GenericGameService<TraceGameSession>(feedbackMessageProvider)
{
    public TraceEvaluationResult GetTraceEvaluation()
    {
        return Session?.GetLastEvaluation();
    }
}