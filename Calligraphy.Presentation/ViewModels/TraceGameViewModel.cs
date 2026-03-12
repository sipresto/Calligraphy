using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.TraceTemplates;
using Calligraphy.Domain.Utility;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class TraceGameViewModel : GameViewModelBase<TraceGameService, TraceGameSession, TraceGameSettings>, ITraceGameViewModel
{
    private string _gameId;
    private TraceTemplate CurrentTemplate { get; set; }
    
    public TraceGameViewModel(TraceGameService service, MainViewModel mainViewModel, GameSettings settings)
        : base(service, mainViewModel, settings)
    {
    }
    
    public void Initialize(string gameId)
    {
        _gameId = gameId;
        Settings = AllSettings.TraceGames[gameId];
        CurrentTemplate = TraceFactory.GetTraceTemplate(Settings.Template);
        Service.InitializeSession(_gameId, CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance, Settings.RequiredAccuracy);
    }

    public event Action DrawingStarted;
    public event Action DrawingEnded;

    public bool IsTimed => false;
    
    public bool EndOnLift => true;
    
    public double GetThickness()
    {
        return Settings.ToleranceDistance * 2;
    }
    
    protected override void RestartGame()
    {
        Service.InitializeSession(_gameId, CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance, Settings.RequiredAccuracy);
        ResetGameState();
    }
    
    public List<StrokePoint> GetTemplatePoints()
    {
        return CurrentTemplate?.GetTemplatePoints() ?? new List<StrokePoint>();
    }
}