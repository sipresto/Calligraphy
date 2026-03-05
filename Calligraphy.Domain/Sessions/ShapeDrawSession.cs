using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class ShapeDrawSession : GameSession
{
    public Shape Shape { get; }

    public ShapeDrawSession(double dpi, Shape shape) : base(dpi)
    {
        Shape = shape;
    }

    protected override int CalculateScore()
    {
        double accuracy = Recognizer.CalculateAccuracy(TotalStroke(), Shape.Name);

        double threshold = Shape.Name switch
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
        var strokeFeedback = AnalyzeStrokes(checkSpeed: false);
        if (strokeFeedback.Type != FeedbackType.Perfect)
            return strokeFeedback.Message;
        
        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}