using Calligraphy.Domain.Configuration;
using System.Runtime.CompilerServices;
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
        switch (category)
        {
            
        }
        CurrentViewModel = new LevelViewModel(this);
    }

    public void ShowSettings()
    {
        CurrentViewModel = App.ServiceProvider.GetRequiredService<SettingsViewModel>();
    }

    public void ShowTutorialForGame(string gameKey)
    {
        var gameSettings = GetSettingsForGameKey(gameKey);
        if (gameSettings == null || gameSettings.Tutorial == null) return;

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
        
        tutorialVm.SetTutorialInfo(info, gameKey); 
        
        CurrentViewModel = tutorialVm;
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