using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public partial class LevelViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;
    
    public LevelViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }
    
    [RelayCommand]
    private void Level(string levelKey) => _mainViewModel.ShowTutorialForGame(levelKey);
    
}