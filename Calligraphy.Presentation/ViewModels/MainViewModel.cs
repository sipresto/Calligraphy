using System.Runtime.CompilerServices;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation.ViewModels;

public class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
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

    public void NavigateToLevels(string categoryName)
    {
        
    }

    // TODO: Replace with IDs later
    public void ShowTutorialForGame(string gameName)
    {
        var tutorialVm = App.ServiceProvider.GetRequiredService<TutorialViewModel>();

        var info = gameName switch
        {
            "InfinityRace" => new TutorialInfo
            {
                PointsExplanation = "Verdien punten door zo snel mogelijk een liggende 8 vorm te tekenen.",
                OneStar = "1 punt",
                TwoStars = "5 punten",
                ThreeStars = "10 punten",
                ShowPressureInfo = false,
                TargetGameViewModelName = nameof(InfinityRaceViewModel)
            },
            "TraceGame" => new TutorialInfo
            {
                PointsExplanation = "Verdien punten door zo naukeurig mogelijk de lijn te tekenen.",
                OneStar = "30 punten",
                TwoStars = "60 punten",
                ThreeStars = "100 punten",
                ShowPressureInfo = true,
                TargetGameViewModelName = nameof(TimedTraceGameViewModel)
            },
            "ShapeDraw" => new TutorialInfo
            {
                PointsExplanation = "Verdien punten door zo goed mogelijk de vorm te overtekenen.",
                OneStar = "40 punten",
                TwoStars = "60 punten",
                ThreeStars = "85 punten",
                ShowPressureInfo = true,
                TargetGameViewModelName = nameof(ShapeDrawViewModel)
            },
            _ => null
        };

        if (info == null) return;
        tutorialVm.SetTutorialInfo(info);
        CurrentViewModel = tutorialVm;
    }
}