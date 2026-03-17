using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public abstract class GenericGameService<TSession>
    where TSession : GameSession
{
    private readonly IRepository _repository;
    private string _gameName;
    private TSession Session { get; set; }

    protected GenericGameService(IRepository repository)
    {
        _repository = repository;
    }

    protected void Initialize(string gameId, Func<TSession> sessionFactory)
    {
        _gameName = gameId;
        Session = sessionFactory();
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        Session.AddStroke(stroke);
    }

    public GameResult FinishGame(StarThresholds thresholds)
    {
        var score = Session.Score;

        var stars = Session.CalculateStars(thresholds);

        var feedbackMessage = Session.GetFeedbackMessage(stars);

        var existingScore = _repository.Get(_gameName)?.Score;

        if (existingScore == null || existingScore < score)
        {
            _repository.Save(new GameResultRecord(_gameName, score, stars, DateTime.Now));
        }

        return new GameResult
        {
            Score = score,
            StarCount = stars,
            FeedbackMessage = feedbackMessage
        };
    }

    public GameResultRecord GetGameScore(string gameId)
    {
        return _repository.Get(gameId);
    }
}