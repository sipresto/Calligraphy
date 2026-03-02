using Calligraphy.Domain;

namespace Calligraphy.Application;

public class InfinityRaceService
{
    private InfinityRaceSession _session;
    private double _dpi;
    
    private static readonly Dictionary<FeedbackType, string[]> Messages =
    new()
    {
        {
            FeedbackType.PressureInconsistent,
            [
                "Probeer de hele tijd even hard te drukken",
                "Let erop dat je pen overal even stevig op het blad staat",
                "Oefen om met een gelijke druk te schrijven"
            ]
        },
        {
            FeedbackType.PressureTooHigh,
            [
                "Probeer iets zachter te drukken",
                "Je mag je pen wat lichter vasthouden",
                "Schrijf eens met wat minder kracht"
            ]
        },
        {
            FeedbackType.PressureTooLow,
            [
                "Probeer iets steviger te drukken",
                "Je mag je pen wat duidelijker op het blad zetten",
                "Zorg dat je pen het papier goed raakt"
            ]
        },
        {
            FeedbackType.SpeedInconsistent,
            [
                "Probeer in een rustig en gelijk tempo te schrijven",
                "Houd je schrijfsnelheid overal ongeveer hetzelfde",
                "Schrijf in een mooi, gelijk ritme"
            ]
        },
        {
            FeedbackType.SpeedTooHigh,
            [
                "Probeer iets rustiger te schrijven",
                "Neem wat meer tijd voor je beweging",
                "Schrijf iets langzamer en gecontroleerd"
            ]
        },
        {
            FeedbackType.SpeedTooLow,
            [
                "Je mag iets sneller schrijven",
                "Probeer je beweging wat vlotter te maken",
                "Schrijf iets soepeler en iets sneller"
            ]
        },
        {
            FeedbackType.Perfect,
            [
                "Dat heb je heel goed gedaan",
                "Wat knap geschreven",
                "Mooi werk, ga zo door"
            ]
        }
    };
    private readonly Random _random = new();
    
    public void InitializeSession(List<Circle> circles, double middle, double dpi)
    {
        _session = new InfinityRaceSession(circles, middle);
        _dpi = dpi;
    }

    public void AddStroke(List<StrokePoint> stroke)
    {
        _session.AddStroke(stroke);
    }

    // TODO: To be moved to generic game service probably
    public int GetScore()
    {
        return _session.CalculateScore();
    }
    
    // TODO: To be moved to generic game service
    public StrokeFeedback AnalyzeStrokes()
    {
        var stroke = _session.GetTotalStroke();

        bool pressureHigh = StrokeAnalysis.IsPressureTooHigh(stroke);
        bool pressureLow = StrokeAnalysis.IsPressureTooLow(stroke);
        bool pressureInconsistent = StrokeAnalysis.IsStandardDeviationOff(stroke);

        bool speedHigh = StrokeAnalysis.IsSpeedTooHigh(stroke, _dpi);
        bool speedLow = StrokeAnalysis.IsSpeedTooLow(stroke, _dpi);

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

        return new StrokeFeedback(GetRandomMessage(type), type);
    }
    
    private string GetRandomMessage(FeedbackType type)
    {
        var options = Messages[type];
        int index = _random.Next(options.Length);
        return options[index];
    }
}