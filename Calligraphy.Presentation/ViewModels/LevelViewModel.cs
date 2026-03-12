using System.Collections.ObjectModel;
using Calligraphy.Domain.Configuration;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class LevelItem
{
    public string Key { get; init; }
    public string CategoryLabel { get; init; }
    public int Level { get; init; }
}

public partial class LevelViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;

    public LevelViewModel(MainViewModel mainViewModel, GameSettings settings, string category)
    {
        _mainViewModel = mainViewModel;
        CategoryTitle = ResolveCategoryTitle(category);
        Levels = BuildLevels(settings, category);
    }

    public string CategoryTitle { get; }
    public ObservableCollection<LevelItem> Levels { get; }


    [RelayCommand]
    private void Level(string levelKey)
    {
        var index = Levels.ToList().FindIndex(l => l.Key == levelKey);
        var nextKey  = (index >= 0 && index + 1 < Levels.Count)
                          ? Levels[index + 1].Key
                          : null;

        _mainViewModel.ShowTutorialForGame(levelKey, nextKey);
    }

    [RelayCommand]
    private void Back() => _mainViewModel.NavigateToCategories();

    private static string ResolveCategoryTitle(string category) => category switch
    {
        "InfinityRace" => "Letters",
        "TraceGames" => "Schetsen",
        "ShapeGames" => "Vormen",
        _ => "Kies een level"
    };

    private static ObservableCollection<LevelItem> BuildLevels(GameSettings settings, string category)
    {
        var items = new List<LevelItem>();

        switch (category)
        {
            case "InfinityRace" when settings.InfinityRace != null:
                items.Add(new LevelItem
                {
                    Key = "InfinityRace",
                    CategoryLabel = "Letters",
                    Level = 0
                });
                break;

            case "TraceGames" when settings.TraceGames != null:
                foreach (var (key, val) in settings.TraceGames)
                    items.Add(new LevelItem
                    {
                        Key = key,
                        CategoryLabel = "Schetsen",
                        Level = val.Level
                    });
                foreach (var (key, val) in settings.TimedTraceGames)
                    items.Add(new LevelItem
                    {
                        Key = key,
                        CategoryLabel = "Schetsen",
                        Level = val.Level
                    });
                break;

            case "ShapeGames" when settings.ShapeGames != null:
                foreach (var (key, val) in settings.ShapeGames)
                    items.Add(new LevelItem
                    {
                        Key = key,
                        CategoryLabel = "Vormen",
                        Level = val.Level
                    });
                break;
        }

        return new ObservableCollection<LevelItem>(
            items.OrderBy(l => l.Level).ToList()
        );
    }
}