namespace Calligraphy.Domain.Sessions;

public class TraceGameSession(List<StrokePoint> templatePoints, double toleranceDistance = 30.0)
    : GameSession
{
    private readonly TraceEvaluator _evaluator = new(templatePoints, toleranceDistance);
    private TraceEvaluationResult _lastEvaluation;

    public override int CalculateScore()
    {
        _lastEvaluation = _evaluator.Evaluate(_strokes);
        return _lastEvaluation.GetQualityScore(); 
    }

    public TraceEvaluationResult GetLastEvaluation()
    {
        return _lastEvaluation;
    }
}