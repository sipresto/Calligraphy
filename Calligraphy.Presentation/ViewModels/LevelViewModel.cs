using System.Collections.ObjectModel;
using Calligraphy.Domain.Configuration;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;


public partial class LevelViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;

    public LevelViewModel(MainViewModel mainViewModel, GameSettings settings, string category)
    {
        _mainViewModel = mainViewModel;
        CategoryTitle = category;
        Levels = BuildLevels(settings, category);
    }

    public string CategoryTitle { get; }
    public ObservableCollection<LevelItem> Levels { get; }


    [RelayCommand]
    private void Level(string levelKey)
    {
        var list = Levels.ToList();
        var index = list.FindIndex(l => l.Key == levelKey);
        var nextKey = (index >= 0 && index + 1 < list.Count) ? list[index + 1].Key : null;

        _mainViewModel.ShowTutorialForGame(levelKey, nextKey);
    }

    [RelayCommand]
    private void Back() => _mainViewModel.NavigateToCategories();


    private static ObservableCollection<LevelItem> BuildLevels(GameSettings settings, string category)
    {
        var items = new List<LevelItem>();

        if (settings.InfinityRace != null)
            if (string.Equals(settings.InfinityRace.Category, category, StringComparison.OrdinalIgnoreCase))
                items.Add(new LevelItem
                {
                    Key = "InfinityRace",
                    DisplayName = !string.IsNullOrEmpty(settings.InfinityRace.GameName)
                        ? settings.InfinityRace.GameName
                        : settings.InfinityRace.Level.ToString(),
                    CategoryLabel = settings.InfinityRace.Category,
                    Level = settings.InfinityRace.Level
                });
        
        if (settings.ShapeGames != null)
            foreach (var (key, val) in settings.ShapeGames)
                if (string.Equals(val.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add(new LevelItem
                    {
                        Key = key,
                        DisplayName = !string.IsNullOrEmpty(val.GameName) ? val.GameName : val.Level.ToString(),
                        CategoryLabel = val.Category,
                        Level = val.Level
                    });
    
        if (settings.TimedTraceGames != null)
            foreach (var (key, val) in settings.TimedTraceGames)
                if (string.Equals(val.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add(new LevelItem
                    {
                        Key = key,
                        DisplayName = !string.IsNullOrEmpty(val.GameName) ? val.GameName : val.Level.ToString(),
                        CategoryLabel = val.Category,
                        Level = val.Level
                    });

        if (settings.TraceGames != null)
            foreach (var (key, val) in settings.TraceGames)
                if (string.Equals(val.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add(new LevelItem
                    {
                        Key = key,
                        DisplayName = !string.IsNullOrEmpty(val.GameName) ? val.GameName : val.Level.ToString(),
                        CategoryLabel = val.Category,
                        Level = val.Level
                    });

        return new ObservableCollection<LevelItem>(
            items.OrderBy(l => l.Level).ThenBy(l => l.Key).ToList()
        );
    }
}