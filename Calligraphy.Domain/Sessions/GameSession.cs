using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public abstract class GameSession
{
    protected readonly List<List<StrokePoint>> _strokes = [];

    private double? Dpi { get; }

    protected GameSession(double? dpi = null)
    {
        Dpi = dpi;
    }
    
    public int Score => CalculateScore();

    public IReadOnlyList<IReadOnlyList<StrokePoint>> Strokes => _strokes;
    
    public void AddStroke(List<StrokePoint> stroke)
    {
        if (stroke is { Count: > 0 })
            _strokes.Add(stroke);
    }

    protected List<StrokePoint> TotalStroke()
    {
        return _strokes
            .SelectMany(s => s)
            .ToList();
    }

    public int CalculateStars(StarThresholds thresholds)
    {
        var score = Score;

        if (score < thresholds.OneStar) return 0;
        if (score < thresholds.TwoStars) return 1;
        if (score < thresholds.ThreeStars) return 2;
        return 3;
    }

    protected abstract int CalculateScore();
    
    public abstract string GetFeedbackMessage(int stars);

    protected StrokeFeedback AnalyzeStrokes(bool checkPressure = true, bool checkSpeed = true)
    {
        var stroke = TotalStroke();

        bool pressureHigh = checkPressure && StrokeAnalysis.IsPressureTooHigh(stroke);
        bool pressureLow = checkPressure && StrokeAnalysis.IsPressureTooLow(stroke);
        bool pressureInconsistent = checkPressure && StrokeAnalysis.IsStandardDeviationOff(stroke);

        bool speedHigh = checkSpeed && Dpi.HasValue && StrokeAnalysis.IsSpeedTooHigh(stroke, Dpi.Value);
        bool speedLow = checkSpeed && Dpi.HasValue && StrokeAnalysis.IsSpeedTooLow(stroke, Dpi.Value);

        FeedbackType type;

        if (pressureInconsistent || (pressureHigh && pressureLow))
            type = FeedbackType.PressureInconsistent;
        else if (pressureHigh)
            type = FeedbackType.PressureTooHigh;
        else if (pressureLow)
            type = FeedbackType.PressureTooLow;
        else if (speedHigh && speedLow)
            type = FeedbackType.SpeedInconsistent;
        else if (speedHigh)
            type = FeedbackType.SpeedTooHigh;
        else if (speedLow)
            type = FeedbackType.SpeedTooLow;
        else
            type = FeedbackType.Perfect;

        return new StrokeFeedback(FeedbackMessageProvider.GetRandomMessage(type), type);
    }
}