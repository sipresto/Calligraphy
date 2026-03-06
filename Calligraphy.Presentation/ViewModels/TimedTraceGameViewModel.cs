using Calligraphy.Application;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.TraceTemplates;
using Calligraphy.Domain.Utility;

namespace Calligraphy.Presentation.ViewModels;

public class TimedTraceGameViewModel : TimedGameViewModelBase<TraceGameService, TraceGameSession, TimedTraceGameSettings>
{
    private TraceTemplate CurrentTemplate { get; set; }
    
    public TimedTraceGameViewModel(TraceGameService service, GameSettings settings)
        : base(service, settings)
    {
    }

    public void Initialize(string gameName)
    {
        Settings = AllSettings.TimedTraceGames[gameName];
        CurrentTemplate = TraceFactory.GetTraceTemplate(Settings.Template);
        Service.InitializeSession(CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance);
        StartWaitPhase();
    }

    public TraceTemplateMetadata GetCurrentTemplateMetadata()
    {
        return CurrentTemplate.GetMetadata();
    }
    
    protected override void RestartGame()
    {
        Service.InitializeSession(CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance);
        base.RestartGame();
    }
}