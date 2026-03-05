using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public abstract class GameViewModelBase<TService, TSession> : ViewModelBase
    where TService : GenericGameService<TSession>
    where TSession : GameSession
{
    protected readonly TService Service;
    
    public event Action Restarted;
    
    public bool HasNextLevel { get; set; } = false;
    public bool IsGameResultVisible => GameResult != null;
    public GameResult GameResult
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsGameResultVisible));
        }
    }
    
    public ICommand RestartCommand { get; }
    
    protected GameViewModelBase(TService service)
    {
        Service = service;
        RestartCommand = new RelayCommand(RestartGame);
    }

    // TODO: no thresholds parameter
    public void FinishGame(List<List<StrokePointDto>> strokes, StarThresholds thresholds)
    {
        foreach (var stroke in strokes)
        {
            var domainStroke = stroke
                .Select(p => new StrokePoint(p.X, p.Y, p.Pressure, p.Timestamp))
                .ToList();
            Service.AddStroke(domainStroke);
        }
        
        GameResult = Service.FinishGame(thresholds);
    }
    
    protected abstract void RestartGame();
    
    protected void ResetGameState()
    {
        GameResult = null;
        Restarted?.Invoke();
    }
}