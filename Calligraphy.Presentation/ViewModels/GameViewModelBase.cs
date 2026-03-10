using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public abstract class GameViewModelBase<TService, TSession, TSettings> : ViewModelBase
    where TService : GenericGameService<TSession>
    where TSession : GameSession
    where TSettings : BaseGameSettings
{
    protected readonly TService Service;
    protected readonly GameSettings AllSettings;
    protected TSettings Settings;
    protected readonly MainViewModel MainViewModel;

    protected GameViewModelBase(TService service, MainViewModel mainViewModel, GameSettings settings)
    {
        Service = service;
        MainViewModel = mainViewModel;
        AllSettings = settings;
        RestartCommand = new RelayCommand(RestartGame);
        MenuCommand = new RelayCommand(Menu);
    }

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
    public ICommand MenuCommand { get; }

    public event Action Restarted;

    public void FinishGame(List<List<StrokePointDto>> strokes)
    {
        foreach (var stroke in strokes)
        {
            var domainStroke = stroke
                .Select(p => new StrokePoint(p.X, p.Y, p.Pressure, p.Timestamp))
                .ToList();
            Service.AddStroke(domainStroke);
        }

        GameResult = Service.FinishGame(Settings.GetThresholds());
    }

    private void Menu()
    {
        MainViewModel.NavigateToCategories();
    }
    
    protected abstract void RestartGame();

    protected void ResetGameState()
    {
        GameResult = null;
        Restarted?.Invoke();
    }
}