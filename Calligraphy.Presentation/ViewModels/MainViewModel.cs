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
}