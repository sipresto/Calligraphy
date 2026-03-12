using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class TraceGameSession : GameSession
{
    private readonly List<StrokePoint> _templatePoints;
    private readonly double _toleranceDistance;
    private readonly double _requiredAccuracy;
    private TraceEvaluationResult _evaluation;

    public TraceGameSession(List<StrokePoint> templatePoints, double toleranceDistance, double requiredAccuracy)
    {
        _templatePoints = templatePoints;
        _toleranceDistance = toleranceDistance;
        _requiredAccuracy = requiredAccuracy;
    }

    protected override int CalculateScore()
    {
        _evaluation = TraceEvaluator.Evaluate(TotalStroke(), _templatePoints, _toleranceDistance, _requiredAccuracy);
        return _evaluation.GetScore();
    }

    public override string GetFeedbackMessage(int stars)
    {
        if (_evaluation != null)
        {
            if (_evaluation.CoverageScore < 0.5)
                return "Probeer de hele lijn te volgen";

            if (_evaluation.AccuracyScore < 0.5)
                return "Blijf dichter bij de lijn";

            if (!_evaluation.DirectionCorrect)
                return "Volg de lijn van links naar rechts";
        }

        var strokeFeedback = AnalyzeStrokes();
        if (strokeFeedback.Type != FeedbackType.Perfect)
            return strokeFeedback.Message;

        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}