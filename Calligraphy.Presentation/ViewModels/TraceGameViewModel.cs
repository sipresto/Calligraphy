using System.Windows.Input;
using System.Windows.Threading;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class TraceGameViewModel : GameViewModelBase
{
    private const int DrawDuration = 30;
    private const int WaitDuration = 3;
    private const int OneStarScore = 30;
    private const int TwoStarScore = 60;
    private const int ThreeStarScore = 85;

    public const double StartX = 80;
    public const double BaselineY = 450;
    public const double TopY = 290;
    public const double LoopWidth = 110;
    public const int LoopCount = 9;
    private const int PointsPerLoop = 5; //higher for more points to trace

    private readonly TraceGameService _service;
    private DispatcherTimer _drawTimer;
    private DispatcherTimer _waitTimer;
    private DateTime _startTime;
    private bool _started;
    private int _score;
    private List<StrokePoint> _templatePoints;

    public bool IsPreviewVisible
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    } = true;

    public string WaitTimerText
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    } = $"{WaitDuration:F0}";

    public string TimerText
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    } = $"{DrawDuration:F0}s";

    public string MascotMessage
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool IsMascotVisible
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public override bool HasNextLevel { get; init; } = false;

    public ICommand RestartCommand { get; }

    public event Action DrawingStarted;
    public event Action DrawingEnded;
    public event Action Restart;

    public TraceGameViewModel(TraceGameService service)
    {
        _service = service;
        RestartCommand = new RelayCommand(RestartGame);
        
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
        var session = new TraceGameSession();
        session.SetTemplate(_templatePoints, toleranceDistance: 30.0);
        
        _service.InitializeSession(session, dpi);

        _startTime = DateTime.Now;
        _waitTimer = new DispatcherTimer(
            new TimeSpan(0, 0, 0, 0, 100),
            DispatcherPriority.Background,
            TickWaitTimer,
            Dispatcher.CurrentDispatcher);

        _drawTimer = new DispatcherTimer(
            new TimeSpan(0, 0, 0, 0, 100),
            DispatcherPriority.Background,
            TickDrawTimer,
            Dispatcher.CurrentDispatcher);
    }

    public void ProcessFinishedDrawing(List<List<StrokePointDto>> strokes)
    {
        foreach (var stroke in strokes)
        {
            var domainStroke = stroke
                .Select(p => new StrokePoint(p.X, p.Y, p.Pressure, p.Timestamp))
                .ToList();

            _service.AddStroke(domainStroke);
        }

        OnGameFinished();
    }

    public string AnalyzeStrokes()
    {
        var feedback = _service.AnalyzeStrokes();
        
        if (feedback.Type != FeedbackType.Perfect)
        {
            return feedback.Message;
        }
        
        return GetTraceAccuracyMessage();
    }

    private string GetTraceAccuracyMessage()
    {
        var traceResult = _service.GetTraceEvaluation();
        
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

    private void StartDrawPhase()
    {
        _startTime = DateTime.Now;
        _drawTimer.Start();
        _started = true;
        IsPreviewVisible = false;
        DrawingStarted?.Invoke();
    }

    private void TickDrawTimer(object sender, EventArgs e)
    {
        if (!_started) return;
        var timeLeft = DrawDuration - (DateTime.Now - _startTime).TotalSeconds;
        TimerText = $"{timeLeft:F0}s";

        if (timeLeft <= 0)
        {
            _drawTimer.Stop();
            TimerText = "0s";
            DrawingEnded?.Invoke();
        }
    }

    private void TickWaitTimer(object sender, EventArgs e)
    {
        var timeLeft = WaitDuration - (DateTime.Now - _startTime).TotalSeconds;
        WaitTimerText = $"{timeLeft:F0}";

        if (timeLeft < 1)
            WaitTimerText = "START";

        if (timeLeft <= 0)
        {
            _waitTimer.Stop();
            StartDrawPhase();
        }
    }

    protected override void OnGameFinished()
    {
        _score = _service.GetScore();
        int stars = CalculateStars(_score, OneStarScore, TwoStarScore, ThreeStarScore);

        var feedback = _service.AnalyzeStrokes();
        var traceResult = _service.GetTraceEvaluation();
        
        string message;

        // Check trace success first
        if (traceResult != null && !traceResult.IsSuccessful)
        {
            stars = Math.Min(stars, 1);
            message = GetTraceAccuracyMessage();
        }
        else if (feedback.Type == FeedbackType.Perfect)
        {
            message = stars switch
            {
                3 => "Geweldig! Je hebt het heel goed gedaan!",
                2 => "Goed gedaan! Het was al bijna perfect!",
                1 => "Niet slecht! Probeer het nog eens en kijk of je meer punten kunt halen!",
                0 => "Blijf oefenen! Je kunt het beter doen als je het nog eens probeert!",
                _ => ""
            };
        }
        else
        {
            message = feedback.Message;
        }

        MascotMessage = message;
        IsMascotVisible = true;

        GameResult = new GameResult { Score = _score, StarCount = stars };
    }

    protected override void RestartGame()
    {
        GameResult = null;
        _score = 0;
        _started = false;
        TimerText = $"{DrawDuration:F0}s";
        WaitTimerText = $"{WaitDuration:F0}";
        IsPreviewVisible = true;
        IsMascotVisible = false;

        Restart?.Invoke();
        _startTime = DateTime.Now;
        _waitTimer.Start();
    }
}