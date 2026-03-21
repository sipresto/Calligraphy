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