using Calligraphy.Domain.Configuration;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly GameSettings _settings;
    private readonly IServiceProvider _services;
    
    public MainViewModel(GameSettings settings, IServiceProvider services)
    {
        _settings = settings;
        _services = services;
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
        CurrentViewModel = new LevelViewModel(this, _settings, category);
    }

    public void ShowSettings()
    {
        CurrentViewModel = App.ServiceProvider.GetRequiredService<SettingsViewModel>();
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
            TargetGameViewModelName = gameSettings.Tutorial.TargetViewModel
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

        return index >= 0 && index + 1 < ordered.Count
            ? ordered[index + 1]
            : null;
    }

    private List<string> GetCategoryKeysFor(string gameKey)
    {
        if (gameKey == "InfinityRace")
            return ["InfinityRace"];

        if (_settings.ShapeGames?.ContainsKey(gameKey) == true)
            return _settings.ShapeGames
                .OrderBy(kv => kv.Value.Level)
                .ThenBy(kv => kv.Key)
                .Select(kv => kv.Key)
                .ToList();

        if (_settings.TimedTraceGames?.ContainsKey(gameKey) == true)
            return _settings.TimedTraceGames
                .OrderBy(kv => kv.Value.Level)
                .ThenBy(kv => kv.Key)
                .Select(kv => kv.Key)
                .ToList();

        if (_settings.TraceGames?.ContainsKey(gameKey) == true)
            return _settings.TraceGames
                .OrderBy(kv => kv.Value.Level)
                .ThenBy(kv => kv.Key)
                .Select(kv => kv.Key)
                .ToList();

        return [];
    }

    private BaseGameSettings GetSettingsForGameKey(string gameKey)
    {
        if (gameKey == "InfinityRace") return _settings.InfinityRace;
        if (_settings.TimedTraceGames?.ContainsKey(gameKey) == true) return _settings.TimedTraceGames[gameKey];
        if (_settings.TraceGames?.ContainsKey(gameKey) == true) return _settings.TraceGames[gameKey];
        if (_settings.ShapeGames?.ContainsKey(gameKey) == true) return _settings.ShapeGames[gameKey];
        return null;
    }

    private static string FormatPoints(int points)
    {
        return points == 1 ? "1 punt" : $"{points} punten";
    }
}