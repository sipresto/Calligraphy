using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public abstract partial class GameViewModelBase<TService, TSession, TSettings> : ViewModelBase, INextLevelAware
    where TService : GenericGameService<TSession>
    where TSession : GameSession
    where TSettings : BaseGameSettings
{
    protected readonly TService Service;
    protected readonly GameSettings AllSettings;
    protected TSettings Settings;
    private readonly MainViewModel _mainViewModel;

    private string _nextLevelKey;

    protected GameViewModelBase(TService service, MainViewModel mainViewModel, GameSettings settings)
    {
        Service = service;
        _mainViewModel = mainViewModel;
        AllSettings = settings;
        RestartCommand = new RelayCommand(RestartGame);
        MenuCommand = new RelayCommand(Menu);
        NextLevelCommand = new RelayCommand(NavigateToNextLevel);
    }

    public bool IsAnimationPlaying
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsPauseButtonVisible));
            OnPropertyChanged(nameof(IsGameResultVisible));
        }
    } = false;

    public bool IsPauseVisible
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsPauseButtonVisible));
            OnPropertyChanged(nameof(IsDrawingEnabled));
        }
    }

    public bool IsPauseButtonVisible => GameResult == null || IsAnimationPlaying;

    public bool IsDrawingEnabled => !IsPauseVisible;

    [RelayCommand]
    private void Pause()
    {
        IsPauseVisible = true;
        OnPause();
        Paused?.Invoke();
    }

    [RelayCommand]
    private void Resume()
    {
        IsPauseVisible = false;
        OnResume();
        Resumed?.Invoke();
    }

    protected virtual void OnPause() { }

    protected virtual void OnResume() { }

    public bool HasNextLevel
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool IsGameResultVisible => GameResult != null && !IsAnimationPlaying;

    public GameResult GameResult
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsGameResultVisible));
            OnPropertyChanged(nameof(IsPauseButtonVisible));
        }
    }

    public int BestScore
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public ICommand RestartCommand { get; }
    public ICommand MenuCommand { get; }
    public ICommand NextLevelCommand { get; }

    public event Action Restarted;
    public event Action Paused;
    public event Action Resumed;
    public void SetNextLevel(string nextLevelKey)
    {
        _nextLevelKey = nextLevelKey;
        HasNextLevel = nextLevelKey != null;
    }

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

        if (GameResult?.Score > BestScore)
            BestScore = GameResult.Score ?? BestScore;
    }

    private void Menu() => _mainViewModel.NavigateToCategories();

    private void NavigateToNextLevel()
    {
        if (_nextLevelKey == null) return;
        _mainViewModel.ShowTutorialForGame(_nextLevelKey);
    }

    protected void LoadBestScore(string gameId)
    {
        BestScore = Service.GetGameScore(gameId)?.Score ?? 0;
    }

    protected abstract void RestartGame();

    protected void ResetGameState()
    {
        IsPauseVisible = false;
        IsAnimationPlaying = false;
        GameResult = null;
        Restarted?.Invoke();
    }
}