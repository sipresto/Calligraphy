using System.Windows.Input;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation.ViewModels;

public class TutorialViewModel : ViewModelBase
{
    private readonly MainViewModel _navigation;
    private readonly IServiceProvider _services;

    public TutorialViewModel(MainViewModel navigation, IServiceProvider services)
    {
        _navigation = navigation;
        _services = services;

        CloseTutorialCommand = new RelayCommand(CloseTutorial);
    }

    public string PointsExplanation { get; set; }
    public string OneStar { get; set; }
    public string TwoStars { get; set; }
    public string ThreeStars { get; set; }
    public bool ShowPressureInfo { get; set; }
    private string TargetGameViewModelName { get; set; }

    public ICommand CloseTutorialCommand { get; }

    public void SetTutorialInfo(TutorialInfo info)
    {
        PointsExplanation = info.PointsExplanation;
        OneStar = info.OneStar;
        TwoStars = info.TwoStars;
        ThreeStars = info.ThreeStars;
        ShowPressureInfo = info.ShowPressureInfo;
        TargetGameViewModelName = info.TargetGameViewModelName;

        OnPropertyChanged(nameof(PointsExplanation));
        OnPropertyChanged(nameof(OneStar));
        OnPropertyChanged(nameof(TwoStars));
        OnPropertyChanged(nameof(ThreeStars));
        OnPropertyChanged(nameof(ShowPressureInfo));
    }

    private void CloseTutorial()
    {
        if (!string.IsNullOrEmpty(TargetGameViewModelName))
        {
            ViewModelBase gameVm = TargetGameViewModelName switch
            {
                nameof(InfinityRaceViewModel) => _services.GetRequiredService<InfinityRaceViewModel>(),
                nameof(TimedTraceGameViewModel) => _services.GetRequiredService<TimedTraceGameViewModel>(),
                nameof(ShapeDrawViewModel) => _services.GetRequiredService<ShapeDrawViewModel>(),
                _ => null
            };

            if (gameVm != null)
            {
                _navigation.CurrentViewModel = gameVm;
            }
        }
    }
}