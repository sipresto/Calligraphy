using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class ShapeDrawSession : GameSession
{
    public ShapeDrawSession(Shape shape)
    {
        Shape = shape;
    }

    public Shape Shape { get; }

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
            "Oval"           => 0.42,
            "Heart"          => 0.40,
            "Arrow"          => 0.38,
            "Cross"          => 0.38,
            "Plus"           => 0.38,
            "Trapezoid"      => 0.40,
            "HalfMoon"       => 0.38,
            "WaningMoon"     => 0.36,
            "FourLeafClover" => 0.36,
            _                => 0.40
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