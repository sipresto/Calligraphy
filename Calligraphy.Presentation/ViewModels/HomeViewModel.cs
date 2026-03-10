using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(MainViewModel mainViewModel)
    {
        PlayCommand = new RelayCommand(mainViewModel.NavigateToCategories);
        //PlayCommand = new RelayCommand(() => mainViewModel.ShowTutorialForGame("ShapeDraw"));
        //PlayCommand = new RelayCommand(() => mainViewModel.ShowTutorialForGame("InfinityRace"));
        //PlayCommand = new RelayCommand(() => mainViewModel.ShowTutorialForGame("TraceGame"));
        ExitCommand = new RelayCommand(ExecuteExit);
    }

    public ICommand PlayCommand { get; }
    public ICommand ExitCommand { get; }

    private void ExecuteExit()
    {
        System.Windows.Application.Current.Shutdown();
    }
}