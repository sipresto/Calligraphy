using System.Collections.ObjectModel;
using Calligraphy.Application;
using Calligraphy.Domain.Configuration;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;


public partial class LevelViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;
    private readonly InfinityRaceService _infinityRaceService;
    private readonly TraceGameService _traceGameService;
    private readonly ShapeDrawService _shapeDrawService;
    private readonly WordGameService _wordGameService;

    public LevelViewModel(MainViewModel mainViewModel, InfinityRaceService infinityRaceService, TraceGameService traceGameService, ShapeDrawService shapeDrawService, WordGameService wordGameService, GameSettings settings, string category)
    {
        _mainViewModel = mainViewModel;
        _infinityRaceService = infinityRaceService;
        _traceGameService = traceGameService;
        _shapeDrawService = shapeDrawService;
        _wordGameService = wordGameService;
        CategoryTitle = category;
        Levels = BuildLevels(settings, category);
        var all = BuildLevels(settings, category);
        EasyLevels  = new ObservableCollection<LevelItem>(all.Where(l => l.Difficulty == "Makkelijk"));
        MediumLevels = new ObservableCollection<LevelItem>(all.Where(l => l.Difficulty == "Normaal"));
        HardLevels  = new ObservableCollection<LevelItem>(all.Where(l => l.Difficulty == "Moeilijk"));
    }

    public string CategoryTitle { get; }
    public ObservableCollection<LevelItem> Levels { get; }
    public ObservableCollection<LevelItem> EasyLevels { get; }
    public ObservableCollection<LevelItem> MediumLevels { get; }
    public ObservableCollection<LevelItem> HardLevels { get; }


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


    private ObservableCollection<LevelItem> BuildLevels(GameSettings settings, string category)
    {
        var items = new List<LevelItem>();

        if (settings.InfinityRace != null)
            foreach (var (key, val) in settings.InfinityRace)
                if (string.Equals(val.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add(new LevelItem
                    {
                        Key = key,
                        DisplayName = !string.IsNullOrEmpty(val.GameName) ? val.GameName : val.Level.ToString(),
                        CategoryLabel = val.Category,
                        Level = val.Level,
                        Stars = _infinityRaceService.GetGameScore(key)?.Stars ?? 0,
                        Difficulty = "Moeilijk"
                    });
        
        if (settings.ShapeGames != null)
            foreach (var (key, val) in settings.ShapeGames)
                if (string.Equals(val.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add(new LevelItem
                    {
                        Key = key,
                        DisplayName = !string.IsNullOrEmpty(val.GameName) ? val.GameName : val.Level.ToString(),
                        CategoryLabel = val.Category,
                        Level = val.Level,
                        Stars = _shapeDrawService.GetGameScore(key)?.Stars ?? 0,
                        Difficulty = "Normaal"
                    });
        if (settings.TimedTraceGames != null)
            foreach (var (key, val) in settings.TimedTraceGames)
                if (string.Equals(val.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add(new LevelItem
                    {
                        Key = key,
                        DisplayName = !string.IsNullOrEmpty(val.GameName) ? val.GameName : val.Level.ToString(),
                        CategoryLabel = val.Category,
                        Level = val.Level,
                        Stars = _traceGameService.GetGameScore(key)?.Stars ?? 0,
                        Difficulty = "Moeilijk"
                    });

        if (settings.TraceGames != null)
            foreach (var (key, val) in settings.TraceGames)
                if (string.Equals(val.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add(new LevelItem
                    {
                        Key = key,
                        DisplayName = !string.IsNullOrEmpty(val.GameName) ? val.GameName : val.Level.ToString(),
                        CategoryLabel = val.Category,
                        Level = val.Level,
                        Stars = _traceGameService.GetGameScore(key)?.Stars ?? 0,
                        Difficulty = "Makkelijk"
                    });
        
        if (settings.WordGames != null)
            foreach (var (key, val) in settings.WordGames)
                if (string.Equals(val.Category, category, StringComparison.OrdinalIgnoreCase))
                    items.Add(new LevelItem
                    {
                        Key = key,
                        DisplayName = !string.IsNullOrEmpty(val.GameName) ? val.GameName : val.Level.ToString(),
                        CategoryLabel = val.Category,
                        Level = val.Level,
                        Stars = _wordGameService.GetGameScore(key)?.Stars ?? 0,
                        Difficulty = "Moeilijk"
                    });

        return new ObservableCollection<LevelItem>(
            items.OrderBy(l => l.Level).ThenBy(l => l.Key).ToList()
        );
    }
}