using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class WordGameSession : GameSession
{
    private readonly List<string> _words;
    private readonly double _toleranceDistance;
    private readonly double _requiredAccuracy;
    private Dictionary<List<StrokePoint>, List<StrokePoint>> _drawingData = new();

    public WordGameSession(List<string> words, double toleranceDistance, double requiredAccuracy)
    {
        _words = words;
        _toleranceDistance = toleranceDistance;
        _requiredAccuracy = requiredAccuracy;
    }

    public void AddLetter(List<StrokePoint> templatePoints, List<StrokePoint> userPoints)
    {
        _drawingData.Add(templatePoints, userPoints);
    }

    protected override int CalculateScore()
    {
        int totalScore = 0;
        
        foreach (var drawing in _drawingData)
        {
            if (drawing.Value == null)
                continue;
            
            var score = TraceEvaluator.Evaluate(drawing.Value, drawing.Key, _toleranceDistance, _requiredAccuracy)
                .GetScore();
            
            totalScore += score;
        }

        totalScore /= _drawingData.Count;

        return totalScore;
    }

    public override string GetFeedbackMessage(int stars)
    {
        var strokeFeedback = AnalyzeStrokes();
        if (strokeFeedback.Type != FeedbackType.Perfect)
            return strokeFeedback.Message;

        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}