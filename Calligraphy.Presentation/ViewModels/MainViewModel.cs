using Calligraphy.Domain.Configuration;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly GameSettings _settings;
    private readonly IServiceProvider _services;
    private readonly LevelViewModelFactory _viewModelFactory;
    
    public MainViewModel(GameSettings settings, IServiceProvider services, LevelViewModelFactory viewModelFactory)
    {
        _settings = settings;
        _services = services;
        _viewModelFactory = viewModelFactory;
        
        NavigateToHome();
    }

    public ViewModelBase CurrentViewModel
    {
        get;
        set => SetProperty(ref field, value);
    }

    public void NavigateToHome()
    {
        CurrentViewModel = new HomeViewModel(this);
    }

    public void NavigateToCategories()
    {
        CurrentViewModel = new CategoryViewModel(this);
    }

    public void NavigateToLevels(string category)
    {
        CurrentViewModel = _viewModelFactory.CreateLevelViewModel(category);
    }
    
    public void NavigateBackToLevels(string gameKey)
    {
        var category = GetSettingsForGameKey(gameKey)?.Category;
        if (!string.IsNullOrEmpty(category))
            NavigateToLevels(category);
        else
            NavigateToCategories();
    }

    public void ShowSettings()
    {
        CurrentViewModel = _services.GetRequiredService<SettingsViewModel>();
    }

    public void ShowTutorialForGame(string gameKey, string nextLevelKey = null)
    {
        var gameSettings = GetSettingsForGameKey(gameKey);
        if (gameSettings?.Tutorial == null) return;

        nextLevelKey ??= GetNextLevelKey(gameKey);

        var info = new TutorialInfo
        {
            PointsExplanation = gameSettings.Tutorial.PointsExplanation,
            OneStar = FormatPoints(gameSettings.StarThresholds[0]),
            TwoStars = FormatPoints(gameSettings.StarThresholds[1]),
            ThreeStars = FormatPoints(gameSettings.StarThresholds[2]),
            ShowPressureInfo = gameSettings.Tutorial.ShowPressureInfo,
            TargetGameViewModelName = gameSettings.Tutorial.TargetViewModel,
            ImageSource = gameSettings.Tutorial.ImageSource
        };

        var tutorialVm = _services.GetRequiredService<TutorialViewModel>();

        tutorialVm.GameStarted += OnGameStarted;

        void OnGameStarted(ViewModelBase gameVm)
        {
            tutorialVm.GameStarted -= OnGameStarted;
            if (nextLevelKey != null && gameVm is INextLevelAware aware)
                aware.SetNextLevel(nextLevelKey);
        }

        tutorialVm.SetTutorialInfo(info, gameKey);
        CurrentViewModel = tutorialVm;
    }

    private string GetNextLevelKey(string gameKey)
    {
        var ordered = GetCategoryKeysFor(gameKey);
        var index   = ordered.IndexOf(gameKey);
        return index >= 0 && index + 1 < ordered.Count ? ordered[index + 1] : null;
    }

    private List<string> GetCategoryKeysFor(string gameKey)
    {
        string category = GetSettingsForGameKey(gameKey)?.Category;
        if (string.IsNullOrEmpty(category)) return [];

        var items = new List<(string Key, int Level)>();

        if (_settings.InfinityRace != null)
            foreach (var (k, v) in _settings.InfinityRace)
                if (string.Equals(v.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add((k, v.Level));
        
        if (_settings.ShapeGames != null)
            foreach (var (k, v) in _settings.ShapeGames)
                if (string.Equals(v.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add((k, v.Level));

        if (_settings.TimedTraceGames != null)
            foreach (var (k, v) in _settings.TimedTraceGames)
                if (string.Equals(v.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add((k, v.Level));

        if (_settings.TraceGames != null)
            foreach (var (k, v) in _settings.TraceGames)
                if (string.Equals(v.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add((k, v.Level));
        
        if (_settings.WordGames != null)
            foreach (var (k, v) in _settings.WordGames)
                if (string.Equals(v.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add((k, v.Level));

        return items.OrderBy(i => i.Level).ThenBy(i => i.Key).Select(i => i.Key).ToList();
    }

    private BaseGameSettings GetSettingsForGameKey(string gameKey)
    {
        if (_settings.InfinityRace?.ContainsKey(gameKey) == true) return _settings.InfinityRace[gameKey];
        if (_settings.TimedTraceGames?.ContainsKey(gameKey) == true) return _settings.TimedTraceGames[gameKey];
        if (_settings.TraceGames?.ContainsKey(gameKey) == true) return _settings.TraceGames[gameKey];
        if (_settings.ShapeGames?.ContainsKey(gameKey) == true) return _settings.ShapeGames[gameKey];
        if (_settings.WordGames?.ContainsKey(gameKey) == true) return _settings.WordGames[gameKey];
        return null;
    }

    private static string FormatPoints(int points)
    {
        return points == 1 ? "1 punt" : $"{points} punten";
    }
}