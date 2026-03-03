using System.Windows.Input;
using System.Windows.Threading;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class TraceGameViewModel : GameViewModelBase
{
    private const int DrawDuration = 20;
    private const int WaitDuration = 3;
    private const int OneStarScore = 1;
    private const int TwoStarScore = 5;
    private const int ThreeStarScore = 10;

    private readonly GameService _service;
    private DispatcherTimer _drawTimer;
    private DispatcherTimer _waitTimer;
    private DateTime _startTime;
    private bool _started = false;
    private int _score = 0;

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

    public TraceGameViewModel(GameService service)
    {
        _service = service;
        RestartCommand = new RelayCommand(RestartGame);
    }

    public void Initialize(double dpi)
    {
        var session = new TraceGameSession();
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
        return feedback.Type == FeedbackType.Perfect ? null : feedback.Message;
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
        string message;

        if (feedback.Type == FeedbackType.Perfect)
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