using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.TraceTemplates;
using Calligraphy.Domain.Utility;

namespace Calligraphy.Presentation.ViewModels;

public class TraceGameViewModel : GameViewModelBase<TraceGameService, TraceGameSession, TraceGameSettings>, ITraceGameViewModel
{
    private string _gameId;
    public TraceTemplate CurrentTemplate { get; private set; }    
    private int _currentSegmentCount = 1;

    public event Action DrawingStarted;
    public event Action DrawingEnded;

    public TraceGameViewModel(TraceGameService service, MainViewModel mainViewModel, GameSettings settings)
        : base(service, mainViewModel, settings)
    {
    }

    public void Initialize(string gameId, string directionImageSource = null)
    {
        DirectionImageSource = directionImageSource;
        _gameId = gameId;
        LoadBestScore(_gameId);
        Settings = AllSettings.TraceGames[gameId];
        CurrentTemplate = TraceFactory.GetTraceTemplate(Settings.Template);
        Service.StartSession(_gameId, CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance, Settings.RequiredAccuracy);

        DrawingStarted?.Invoke();
    }

    public bool IsTimed => false;

    public bool EndOnLift => true;

    public List<StrokePoint> TemplatePoints => CurrentTemplate?.GetTemplatePoints() ?? [];

    public double TemplateThickness => Settings.ToleranceDistance * 2;

    public string DirectionImageSource { get; private set; }

    public bool SegmentCountCompleted()
    {
        if (Settings.SegmentCount > _currentSegmentCount)
        {
            _currentSegmentCount++;
            return false;
        }
        return true;
    }

    protected override void RestartGame()
    {
        Service.StartSession(_gameId, CurrentTemplate.GetTemplatePoints(), Settings.ToleranceDistance, Settings.RequiredAccuracy);
        _currentSegmentCount = 1;
        LoadBestScore(_gameId);
        ResetGameState();
        DrawingStarted?.Invoke();
    }
}