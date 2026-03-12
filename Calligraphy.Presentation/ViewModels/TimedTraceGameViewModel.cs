using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.TraceTemplates;
using Calligraphy.Domain.Utility;

namespace Calligraphy.Presentation.ViewModels;

public class TimedTraceGameViewModel : TimedGameViewModelBase<TraceGameService, TraceGameSession, TimedTraceGameSettings>
{
    private string _gameId;
    
    private TraceTemplate _currentTemplate;
    public TraceTemplate CurrentTemplate 
    { 
        get => _currentTemplate;
        private set 
        { 
            _currentTemplate = value; 
            OnPropertyChanged();
        }
    }
    
    public TimedTraceGameViewModel(TraceGameService service, MainViewModel mainViewModel, GameSettings settings)
        : base(service, mainViewModel, settings) { }

    public void Initialize(string gameId)
    {
        _gameId = gameId;
        Settings = AllSettings.TimedTraceGames[gameId];
        CurrentTemplate = TraceFactory.GetTraceTemplate(Settings.Template);
        
        Service.InitializeSession(_gameId, CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance);
        StartWaitPhase();
    }

    public List<StrokePoint> GetTemplatePoints()
    {
        return _currentTemplate.GetTemplatePoints();
    }

    public double GetThickness()
    {
        return Settings.ToleranceDistance*2;
    }
    
    protected override void RestartGame()
    {
        Service.InitializeSession(_gameId, CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance);
        base.RestartGame();
    }
}