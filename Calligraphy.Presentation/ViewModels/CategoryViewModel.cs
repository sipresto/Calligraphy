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
    private void ChooseCategory(string category) => _mainViewModel.NavigateToLevels(category);
}