using CommunityToolkit.Mvvm.ComponentModel;

namespace Calligraphy.Presentation.ViewModels;

public class MainViewModel : ObservableObject
{
    private IPageViewModel? _currentViewModel;

    public IPageViewModel? CurrentViewModel
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
        CurrentViewModel = new InfinityRaceViewModel();
    }
}