using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public partial class CategoryViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;
    
    public CategoryViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    [RelayCommand]
    private void LetterCategory() => _mainViewModel.ShowTutorialForGame("LowercaseG");
    
    [RelayCommand]
    private void ShapeCategory() => _mainViewModel.ShowTutorialForGame("DiamondShapeGame");
    
    [RelayCommand]
    // private void TraceCategory() => _mainViewModel.ShowTutorialForGame("TimedTraceLoop");
    // private void TraceCategory() => _mainViewModel.ShowTutorialForGame("TimedTraceHedge");
    // private void TraceCategory() => _mainViewModel.ShowTutorialForGame("TimedTraceCastle");
    // private void TraceCategory() => _mainViewModel.ShowTutorialForGame("TimedTraceWave");
    private void TraceCategory() => _mainViewModel.ShowTutorialForGame("TimedTraceMountain");
    
    
}