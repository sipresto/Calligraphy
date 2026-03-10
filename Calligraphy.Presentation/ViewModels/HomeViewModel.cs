using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;

    public HomeViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }
    
    [RelayCommand]
    private void Play() => _mainViewModel.NavigateToCategories();

    [RelayCommand]
    private void Settings() => _mainViewModel.ShowSettings();

    [RelayCommand]
    private void Exit() => System.Windows.Application.Current.Shutdown();
}