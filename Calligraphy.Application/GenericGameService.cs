using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Application;

public abstract class GenericGameService<TSession>
    where TSession : GameSession
{
    protected TSession Session { get; private set; }

    protected void InitializeSession(TSession session)
    {
        Session = session;
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        Session.AddStroke(stroke);
    }
    
    // TODO: temporary StarThreshold as parameter
    public GameResult FinishGame(StarThresholds thresholds)
    {
        var score = Session.Score;

        //var thresholds = GetStarThresholds();
        var stars = Session.CalculateStars(thresholds);

        var feedbackMessage = Session.GetFeedbackMessage(stars);

        return new GameResult
        {
            Score = score,
            StarCount = stars,
            FeedbackMessage = feedbackMessage
        };
    }
}