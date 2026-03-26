namespace Calligraphy.Domain.Configuration;

using System.Collections.Generic;

public class GameSettings
{
    public Dictionary<string, InfinityRaceSettings> InfinityRace { get; init; }
    public Dictionary<string, TimedTraceGameSettings> TimedTraceGames { get; init; }
    public Dictionary<string, TraceGameSettings> TraceGames { get; init; }
    public Dictionary<string, ShapeGameSettings> ShapeGames { get; init; }
    public Dictionary<string, WordGameSettings> WordGames { get; init; }
    public Dictionary<string, LetterStringGameSettings> LetterStringGames { get; init; }
}

public abstract class BaseGameSettings
{
    public int[] StarThresholds { get; set; }
    public int Level { get; set; } = 0;
    public string Category { get; set; } = string.Empty;
    public string GameName { get; set; } = string.Empty;
    public TutorialSettings Tutorial { get; init; }
    public string Difficulty { get; set; } = "Makkelijk";
    
    // Abstract get-only property ensures every derived class assigns a ViewModel,
    // but the JSON deserializer won't look for it in your JSON file.
    public abstract string TargetViewModel { get; }
    
    public StarThresholds GetThresholds() => new (StarThresholds[0], StarThresholds[1], StarThresholds[2]);
}

public abstract class TimedGameSettings : BaseGameSettings
{
    public int DrawDuration { get; set; }
}

public class InfinityRaceSettings : TimedGameSettings
{
    public override string TargetViewModel => "InfinityRaceViewModel";
}

public class TimedTraceGameSettings : TimedGameSettings
{
    public string Template { get; set; }
    public double ToleranceDistance { get; set; }
    public double RequiredAccuracy { get; set; }
    public override string TargetViewModel => "TimedTraceGameViewModel";
}

public class TraceGameSettings : BaseGameSettings
{
    public string Template { get; set; }
    public double ToleranceDistance { get; set; }
    public double RequiredAccuracy { get; set; }
    public int SegmentCount { get; set; } = 1;
    public override string TargetViewModel => "TraceGameViewModel";
}

public class ShapeGameSettings : BaseGameSettings
{
    public string Shape { get; set; }
    public override string TargetViewModel => "ShapeDrawViewModel";
}

public class WordGameSettings : BaseGameSettings
{
    public double ToleranceDistance { get; set; }
    public double RequiredAccuracy { get; set; }
    public List<WordPosition> Words { get; set; }
    public string ImageSource { get; set; }
    public override string TargetViewModel => "WordGameViewModel";
}

public class WordPosition
{
    public string Word { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}

public class LetterStringGameSettings : BaseGameSettings
{
    public double ToleranceDistance { get; set; }
    public double RequiredAccuracy { get; set; }
    public string LetterString { get; set; }
    public int SegmentCount { get; set; } = 1;
    public override string TargetViewModel => "LetterStringGameViewModel";
}

public class TutorialSettings
{
    public string PointsExplanation { get; init; }
    public bool ShowPressureInfo { get; init; }
    public string ImageSource { get; init; }
}