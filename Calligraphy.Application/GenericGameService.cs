using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class GenericGameService<TSession>(FeedbackMessageProvider feedbackMessageProvider)
    where TSession : GameSession
{
    protected TSession Session { get; private set; }
    private double Dpi { get; set; }

    public void InitializeSession(TSession session, double dpi)
    {
        Session = session;
        Dpi = dpi;
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        Session.AddStroke(stroke);
    }

    public int GetScore()
    {
        return Session.CalculateScore();
    }

    public StrokeFeedback AnalyzeStrokes()
    {
        var stroke = Session.TotalStroke();

        bool pressureHigh = StrokeAnalysis.IsPressureTooHigh(stroke);
        bool pressureLow = StrokeAnalysis.IsPressureTooLow(stroke);
        bool pressureInconsistent = StrokeAnalysis.IsStandardDeviationOff(stroke);
        bool speedHigh = StrokeAnalysis.IsSpeedTooHigh(stroke, Dpi);
        bool speedLow = StrokeAnalysis.IsSpeedTooLow(stroke, Dpi);

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

        return new StrokeFeedback(feedbackMessageProvider.GetRandomMessage(type), type);
    }
}