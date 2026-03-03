namespace Calligraphy.Domain.Sessions;

public class TraceGameSession(List<StrokePoint> templatePoints, double toleranceDistance = 30.0)
    : GameSession
{
    private TraceEvaluationResult _evaluation;

    public override int CalculateScore()
    {
        _evaluation = TraceEvaluator.Evaluate(TotalStroke(), templatePoints, toleranceDistance);
        return _evaluation.GetQualityScore(); 
    }

    public TraceEvaluationResult GetEvaluation()
    {
        return _evaluation;
    }
}