using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class ShapeDrawSession : GameSession
{
    private readonly Shape _shape;
    
    public ShapeDrawSession(Shape shape)
    {
        _shape = shape;
    }

    protected override int CalculateScore()
    {
        double accuracy = Recognizer.CalculateAccuracy(TotalStroke(), _shape.Name);

        double threshold = _shape.Name switch
        {
            "Circle" => 0.45,
            "Square" => 0.42,
            "Triangle" => 0.40,
            "Diamond" => 0.40,
            "Star" => 0.38,
            "Pentagon" => 0.40,
            "Hexagon" => 0.40,
            _ => 0.40
        };

        return accuracy >= threshold
            ? (int)Math.Round(accuracy * 100)
            : 0;
    }

    public override string GetFeedbackMessage(int stars)
    {
        var strokeFeedback = AnalyzeStrokes();
        if (strokeFeedback.Type != FeedbackType.Perfect)
            return strokeFeedback.Message;

        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}