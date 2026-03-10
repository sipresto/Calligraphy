using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class CategoryViewModel : ViewModelBase
{
    public CategoryViewModel(MainViewModel mainViewModel)
    {
        LetterCategoryCommand = new RelayCommand(() => mainViewModel.ShowTutorialForGame(""));
        ShapeCategoryCommand = new RelayCommand(() => mainViewModel.ShowTutorialForGame("ShapeDraw"));
        TraceCategoryCommand = new RelayCommand(() => mainViewModel.ShowTutorialForGame("TraceGame"));
    }
    
    public ICommand LetterCategoryCommand { get; }
    public ICommand ShapeCategoryCommand { get; }
    public ICommand TraceCategoryCommand { get; }
    
}