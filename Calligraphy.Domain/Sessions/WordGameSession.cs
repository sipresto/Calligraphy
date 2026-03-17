using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class WordGameSession : GameSession
{
    private List<string> _words;
    
    public WordGameSession(List<string> words)
    {
        _words = words;
    }
    
    protected override int CalculateScore()
    {
        throw new NotImplementedException();
    }

    public override string GetFeedbackMessage(int stars)
    {
        var strokeFeedback = AnalyzeStrokes();
        if (strokeFeedback.Type != FeedbackType.Perfect)
            return strokeFeedback.Message;

        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}