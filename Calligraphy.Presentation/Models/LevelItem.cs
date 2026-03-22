using CommunityToolkit.Mvvm.ComponentModel;

namespace Calligraphy.Presentation.Models;

public class LevelItem : ObservableObject
{
    public string Key { get; init; }
    public string DisplayName { get; init; }
    public string CategoryLabel { get; init; }
    public int Level { get; init; }
    public int Stars { get; init; }
    public string Difficulty { get; set; } // "Makkelijk", "Normaal", "Moeilijk"

}