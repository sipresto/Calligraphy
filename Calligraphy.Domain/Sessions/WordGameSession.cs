using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class WordGameSession : GameSession
{
    private readonly double _toleranceDistance;
    private readonly double _requiredAccuracy;
    private Dictionary<string, List<(List<StrokePoint> TemplatePoints, List<StrokePoint> UserPoints)>> _drawingData = new();
    private List<string> _wrongLetters = [];
    private double _accuracyScore = 0;
    private double _coverageScore = 0;

    public WordGameSession(double toleranceDistance, double requiredAccuracy)
    {
        _toleranceDistance = toleranceDistance;
        _requiredAccuracy = requiredAccuracy;
    }

    public void AddLetter(string name, List<StrokePoint> templatePoints, List<StrokePoint> userPoints)
    {
        if (!_drawingData.ContainsKey(name))
            _drawingData[name] = [];

        _drawingData[name].Add((templatePoints, userPoints));
    }

    protected override int CalculateScore()
    {
        int totalScore = 0;
        double totalAccuracy = 0;
        double totalCoverage = 0;
        int totalAttempts = 0;
        
        foreach (var drawing in _drawingData)
        {
            if (!drawing.Value.Any())
                continue;

            foreach (var attempt in drawing.Value)
            {
                var result = TraceEvaluator.Evaluate(
                    attempt.UserPoints,
                    attempt.TemplatePoints,
                    _toleranceDistance,
                    _requiredAccuracy);

                if (!result.DirectionCorrect && attempt.UserPoints.Count != 0 && !_wrongLetters.Contains(drawing.Key))
                {
                    _wrongLetters.Add(drawing.Key);
                } 

                totalScore += result.GetScore();
                totalAccuracy += result.AccuracyScore;
                totalCoverage += result.CoverageScore;
                totalAttempts++;
            }
        }
        
        if (totalAttempts == 0) return 0;

        totalScore /= totalAttempts;
        _accuracyScore = totalAccuracy / totalAttempts;
        _coverageScore = totalCoverage / totalAttempts;

        return totalScore;
    }

    public override string GetFeedbackMessage(int stars)
    {
        if (_wrongLetters.Count != 0)
            return FeedbackMessageProvider.GetRandomWordWrongDirectionMessage(_wrongLetters);
        
        if (_accuracyScore < 0.5)
            return FeedbackMessageProvider.GetRandomMessage(FeedbackType.WordAccuracy);
        
        if (_coverageScore < 0.5)
            return FeedbackMessageProvider.GetRandomMessage(FeedbackType.WordCoverage);
        
        var strokeFeedback = AnalyzeStrokes();
        if (strokeFeedback.Type != FeedbackType.Perfect)
            return strokeFeedback.Message;

        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}