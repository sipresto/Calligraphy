using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class GenericGameService<TSession>
    where TSession : GameSession
{
    protected TSession Session { get; private set; }
    private double? Dpi { get; set; }

    protected void InitializeSession(TSession session, double? dpi = null)
    {
        Session = session;
        Dpi = dpi;
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        Session.AddStroke(stroke);
    }

    // TODO: retrieve starthresholds from db instead of parameter
    public (int, int) GetScoreAndStars(StarThresholds starThresholds)
    {
        var score = Session.CalculateScore();
        return (score, Session.CalculateStars(score, starThresholds));
    }

    public StrokeFeedback AnalyzeStrokes(bool checkPressure = true, bool checkSpeed = true)
    {
        var stroke = Session.TotalStroke();

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