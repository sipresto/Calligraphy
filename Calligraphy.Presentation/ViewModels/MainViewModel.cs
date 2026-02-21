namespace Calligraphy.Presentation.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    public MainViewModel()
    {
        CurrentViewModel = new InfinityRaceViewModel();
    }
}