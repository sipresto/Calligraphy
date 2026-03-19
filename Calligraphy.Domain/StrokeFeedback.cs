namespace Calligraphy.Domain;

public class StrokeFeedback
{
    public StrokeFeedback(string message, FeedbackType type)
    {
        Message = message;
        Type = type;
    }

    public string Message { get; }
    public FeedbackType Type { get; }
}

public enum FeedbackType
{
    PressureTooHigh,
    PressureTooLow,
    PressureInconsistent,
    InfinityWrongDirection,
    InfinityCirclesHit,
    TraceWrongDirection,
    TraceAccuracy,
    TraceCoverage,
    WordAccuracy,
    WordCoverage,
    Perfect
}