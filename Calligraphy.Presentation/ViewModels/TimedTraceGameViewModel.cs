using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Utility;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class TimedTraceGameViewModel : TimedGameViewModelBase<TraceGameService>
{
    public const double StartX = 80;
    public const double BaselineY = 450;
    public const double TopY = 290;
    public const double LoopWidth = 110;
    public const int LoopCount = 9;
    private const int PointsPerLoop = 100; //higher for more points to trace
    
    private readonly List<StrokePoint> _templatePoints;
    
    public override bool HasNextLevel { get; init; } = false;

    public TimedTraceGameViewModel(TraceGameService service)
        : base(service, 30)
    {
        _templatePoints = TraceTemplateGenerator.GenerateHopPattern(
            StartX,
            BaselineY,
            TopY,
            LoopWidth,
            LoopCount,
            PointsPerLoop);
    }

    public void Initialize(double dpi)
    {
        Service.InitializeSession(dpi, _templatePoints, 30.0);
    }

    public override void ProcessFinishedDrawing(List<List<StrokePointDto>> strokes)
    {
        foreach (var stroke in strokes)
        {
            var domainStroke = stroke
                .Select(p => new StrokePoint(p.X, p.Y, p.Pressure, p.Timestamp))
                .ToList();

            Service.AddStroke(domainStroke);
        }

        OnGameFinished();
    }

    public string AnalyzeStrokes()
    {
        var feedback = Service.AnalyzeStrokes();
        
        if (feedback.Type != FeedbackType.Perfect)
        {
            return feedback.Message;
        }
        
        return GetTraceAccuracyMessage();
    }

    private string GetTraceAccuracyMessage()
    {
        var traceResult = Service.GetTraceEvaluation();
        
        if (traceResult == null || traceResult.IsSuccessful)
            return null;

        if (traceResult.CoveragePercentage < 0.5)
            return "Probeer de hele lijn te volgen";
        
        if (traceResult.AverageDeviation > 40)
            return "Blijf dichter bij de lijn";
        
        if (!traceResult.DirectionCorrect)
            return "Volg de lijn van links naar rechts";
        
        return "Bijna goed! Probeer het nog eens";
    }

    protected override void OnGameFinished()
    {
        (Score, int stars) = Service.GetScoreAndStars(new StarThresholds(30, 60, 85));

        var feedback = Service.AnalyzeStrokes();
        var traceResult = Service.GetTraceEvaluation();
        
        string message;

        // Check trace success first
        if (traceResult != null && !traceResult.IsSuccessful)
        {
            stars = Math.Min(stars, 0);
            message = GetTraceAccuracyMessage();
        }
        else if (feedback.Type == FeedbackType.Perfect)
        {
            message = GetStarMessage(stars);
        }
        else
        {
            message = feedback.Message;
        }

        MascotMessage = message;
        IsMascotVisible = true;

        GameResult = new GameResult { Score = Score, StarCount = stars };
    }

    protected override void OnRestart()
    {
        GameResult = null;
        Score = 0;
        IsMascotVisible = false;
        RaiseRestarted();
    }
}