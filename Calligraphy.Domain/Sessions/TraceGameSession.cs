using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class TraceGameSession : GameSession
{
    private readonly List<StrokePoint> _templatePoints;
    private readonly double _toleranceDistance;
    private TraceEvaluationResult _evaluation;

    public TraceGameSession(List<StrokePoint> templatePoints, double toleranceDistance)
    {
        _templatePoints = templatePoints;
        _toleranceDistance = toleranceDistance;
    }

    protected override int CalculateScore()
    {
        _evaluation = TraceEvaluator.Evaluate(TotalStroke(), _templatePoints, _toleranceDistance);
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

            return "Bijna goed! Probeer het nog eens";
        }

        var strokeFeedback = AnalyzeStrokes();
        if (strokeFeedback.Type != FeedbackType.Perfect)
            return strokeFeedback.Message;

        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}