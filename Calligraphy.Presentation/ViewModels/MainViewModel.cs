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
        CurrentViewModel = App.ServiceProvider.GetRequiredService<InfinityRaceViewModel>();
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
            _ => null
        };

        if (info != null)
        {
            tutorialVm.SetTutorialInfo(info);
            CurrentViewModel = tutorialVm;
        }
    }
}