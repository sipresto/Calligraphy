using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation.ViewModels;

public class MainViewModel : ObservableObject
{
    private ViewModelBase _currentViewModel;

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public MainViewModel()
    {
        NavigateToHome();
    }

    public void NavigateToHome()
    {
        CurrentViewModel = new HomeViewModel(this);
    }

    public void NavigateToGame()
    {
        CurrentViewModel = App.ServiceProvider.GetRequiredService<TraceGameViewModel>();
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
                ShowPressureInfo = true,
                ShowSpeedInfo = true,
                TargetGameViewModelName = nameof(InfinityRaceViewModel)
            },
            "TraceGame" => new TutorialInfo
            {
                PointsExplanation = "Verdien punten door zo naukeurig mogelijk de lijn te tekenen.",
                OneStar = "30 punten",
                TwoStars = "60 punten",
                ThreeStars = "100 punten",
                ShowPressureInfo = true,
                ShowSpeedInfo = true,
                TargetGameViewModelName = nameof(TraceGameViewModel)
            },
            "ShapeDraw" => new TutorialInfo
            {
                PointsExplanation = "Verdien punten door zo goed mogelijk de vorm te overtekenen.",
                OneStar = "40 punten",
                TwoStars = "60 punten",
                ThreeStars = "85 punten",
                ShowPressureInfo = true,
                ShowSpeedInfo = true,
                TargetGameViewModelName = nameof(ShapeDrawViewModel)
            },
            _ => null
        };

        if (info != null)
        {
            tutorialVm.SetTutorialInfo(info);
            CurrentViewModel = tutorialVm;
        }
    }
}