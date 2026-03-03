namespace Calligraphy.Domain;

public class StrokeFeedback
{
    public string Message { get; }
    public FeedbackType Type { get; }

    public StrokeFeedback(string message, FeedbackType type)
    {
        Message = message;
        Type = type;
    }
}

public enum FeedbackType
{
    PressureTooHigh,
    PressureTooLow,
    PressureInconsistent,
    SpeedTooHigh,
    SpeedTooLow,
    SpeedInconsistent,
    Perfect
}