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
        double accuracy = Recognizer.CalculateAccuracy(Strokes, Shape.Name);

        return (int)Math.Round(accuracy * 100);
    }

    public override string GetFeedbackMessage(int stars)
    {
        var strokeFeedback = AnalyzeStrokes();
        if (strokeFeedback.Type != FeedbackType.Perfect)
            return strokeFeedback.Message;

        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}