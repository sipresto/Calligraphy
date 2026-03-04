using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : TimedGameViewModelBase<InfinityRaceService>
{
    // TODO: Magic numbers
    public InfinityRaceViewModel(InfinityRaceService service)
        : base(service, 20)
    {
    }

    public void Initialize(List<RaceCircle> circles)
    {
        Service.InitializeSession(circles);
        StartWaitPhase();
    }

    public override void ProcessFinishedDrawing(List<List<StrokePointDto>> strokes)
    {
        foreach (var stroke in strokes)
        {
            var domainStroke = stroke.Select(p => new StrokePoint(p.X, p.Y)).ToList();
            Service.AddStroke(domainStroke);
        }
        OnGameFinished();
    }

    protected override void OnGameFinished()
    {
        (Score, int stars) = Service.GetScoreAndStars(new StarThresholds(1, 5, 10));

        var feedback = Service.AnalyzeStrokes();
        MascotMessage = feedback.Type == FeedbackType.Perfect 
            ? GetStarMessage(stars) 
            : feedback.Message;
        IsMascotVisible = true;
        GameResult = new GameResult { Score = Score, StarCount = stars };
    }

    protected override void OnRestart()
    {
        GameResult = null;
        Score = 0;
        IsMascotVisible = false;
        RaiseRestarted();
    }
}