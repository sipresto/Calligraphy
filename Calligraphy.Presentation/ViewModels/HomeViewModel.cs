using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ICommand PlayCommand { get; }
    public ICommand ExitCommand { get; }


    public HomeViewModel(MainViewModel mainViewModel)
    {
        PlayCommand = new RelayCommand(() => mainViewModel.ShowTutorialForGame("InfinityRace"));
        ExitCommand = new RelayCommand(ExecuteExit);

    }
    
    private void ExecuteExit()
    {
        System.Windows.Application.Current.Shutdown();
    }
}