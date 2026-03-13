using System.Windows.Input;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation.ViewModels;

public partial class TutorialViewModel : ViewModelBase
{
    private readonly MainViewModel _navigation;
    private readonly IServiceProvider _services;

    public TutorialViewModel(MainViewModel navigation, IServiceProvider services)
    {
        _navigation = navigation;
        _services = services;
    }

    public string PointsExplanation { get; set; }
    public string OneStar { get; set; }
    public string TwoStars { get; set; }
    public string ThreeStars { get; set; }
    public bool ShowPressureInfo { get; set; }
    private string TargetGameViewModelName { get; set; }
    private string GameKey { get; set; }
    
    public event Action<ViewModelBase> GameStarted;

    public void SetTutorialInfo(TutorialInfo info, string gameKey)
    {
        PointsExplanation = info.PointsExplanation;
        OneStar = info.OneStar;
        TwoStars = info.TwoStars;
        ThreeStars = info.ThreeStars;
        ShowPressureInfo = info.ShowPressureInfo;
        TargetGameViewModelName = info.TargetGameViewModelName;
        GameKey = gameKey;

        OnPropertyChanged(nameof(PointsExplanation));
        OnPropertyChanged(nameof(OneStar));
        OnPropertyChanged(nameof(TwoStars));
        OnPropertyChanged(nameof(ThreeStars));
        OnPropertyChanged(nameof(ShowPressureInfo));
    }

    [RelayCommand]
    private void CloseTutorial()
    {
        if (string.IsNullOrEmpty(TargetGameViewModelName)) return;

        ViewModelBase gameVm = null;

        if (TargetGameViewModelName == nameof(InfinityRaceViewModel))
        {
            gameVm = _services.GetRequiredService<InfinityRaceViewModel>();
        }
        else if (TargetGameViewModelName == nameof(TimedTraceGameViewModel))
        {
            var vm = _services.GetRequiredService<TimedTraceGameViewModel>();
            vm.Initialize(GameKey);
            gameVm = vm;
        }
        else if (TargetGameViewModelName == nameof(ShapeDrawViewModel))
        {
            var vm = _services.GetRequiredService<ShapeDrawViewModel>();
            vm.Initialize(GameKey);
            gameVm = vm;
        }

        if (gameVm == null) return;

        _navigation.CurrentViewModel = gameVm;
        GameStarted?.Invoke(gameVm);
    }
    
    [RelayCommand]
    private void Menu() => _navigation.NavigateBackToLevels(GameKey);
}