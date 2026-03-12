using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.TraceTemplates;
using Calligraphy.Domain.Utility;

namespace Calligraphy.Presentation.ViewModels;

public class TimedTraceGameViewModel : TimedGameViewModelBase<TraceGameService, TraceGameSession, TimedTraceGameSettings>, ITraceGameViewModel
{
    private string _gameId;
    private TraceTemplate CurrentTemplate { get; set; }
    
    public TimedTraceGameViewModel(TraceGameService service, MainViewModel mainViewModel, GameSettings settings)
        : base(service, mainViewModel, settings)
    {
    }

    public void Initialize(string gameId)
    {
        _gameId = gameId;
        Settings = AllSettings.TimedTraceGames[gameId];
        CurrentTemplate = TraceFactory.GetTraceTemplate(Settings.Template);
        Service.InitializeSession(_gameId, CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance, Settings.RequiredAccuracy);
        StartWaitPhase();
    }

    public List<StrokePoint> GetTemplatePoints()
    {
        return CurrentTemplate.GetTemplatePoints();
    }

    public double GetThickness()
    {
        return Settings.ToleranceDistance * 2;
    }

    public bool IsTimed => true;

    public bool EndOnLift => false;

    protected override void RestartGame()
    {
        Service.InitializeSession(_gameId, CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance, Settings.RequiredAccuracy);
        base.RestartGame();
    }
}