using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class HomeViewModel : IPageViewModel
{
    public ICommand PlayCommand { get; }

    public HomeViewModel(MainViewModel mainViewModel)
    {
        PlayCommand = new RelayCommand(() => mainViewModel.NavigateToGame());
        
    }
}