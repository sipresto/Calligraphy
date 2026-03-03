namespace Calligraphy.Domain;

public class TraceGameSession : IGameSession
{
    private readonly List<List<StrokePoint>> _strokes = [];
    private TraceEvaluator _evaluator;
    private TraceEvaluationResult _lastEvaluation;

    public void SetTemplate(List<StrokePoint> templatePoints, double toleranceDistance = 30.0)
    {
        _evaluator = new TraceEvaluator(templatePoints, toleranceDistance);
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        if (stroke is { Count: > 0 })
            _strokes.Add(stroke);
    }

    public List<StrokePoint> GetTotalStroke()
    {
        return _strokes.SelectMany(s => s).ToList();
    }

    public int CalculateScore()
    {
        _lastEvaluation = _evaluator.Evaluate(_strokes);
        return _lastEvaluation.GetQualityScore(); 
    }

    public TraceEvaluationResult GetLastEvaluation()
    {
        return _lastEvaluation;
    }
}