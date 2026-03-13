namespace Calligraphy.Domain.Configuration;

public class GameSettings
{
    public InfinityRaceSettings InfinityRace { get; init; }
    public Dictionary<string, TimedTraceGameSettings> TimedTraceGames { get; init; }
    public Dictionary<string, TraceGameSettings> TraceGames { get; init; }
    public Dictionary<string, ShapeGameSettings> ShapeGames { get; init; }
}

public abstract class BaseGameSettings
{
    public int[] StarThresholds { get; set; }
    public int Level { get; set; } = 0;
    public string Category { get; set; } = string.Empty;
    public string GameName { get; set; } = string.Empty;
    public TutorialSettings Tutorial { get; init; }
    
    public StarThresholds GetThresholds() => new (StarThresholds[0], StarThresholds[1], StarThresholds[2]);
}

public abstract class TimedGameSettings : BaseGameSettings
{
    public int DrawDuration { get; set; }
}

public class InfinityRaceSettings : TimedGameSettings
{
}

public class TimedTraceGameSettings : TimedGameSettings
{
    public string Template { get; set; }
    public double ToleranceDistance { get; set; }
}

public class TraceGameSettings : BaseGameSettings
{
    public string Template { get; set; }
    public double ToleranceDistance { get; set; }
}

public class ShapeGameSettings : BaseGameSettings
{
    public string Shape { get; set; }
}

public class TutorialSettings
{
    public string PointsExplanation { get; init; }
    public bool ShowPressureInfo { get; init; }
    public string TargetViewModel { get; init; }
}