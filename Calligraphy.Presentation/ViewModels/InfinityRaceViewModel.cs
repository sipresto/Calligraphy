using System.Windows.Input;
using System.Windows.Threading;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Commands;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : ViewModelBase
{
    private const int DrawDuration = 20;
    private const int WaitDuration = 3;
    private InfinityRaceService _service;
    
    private DispatcherTimer _drawTimer;
    private DispatcherTimer _waitTimer;
    private DateTime _startTime;
    private bool _started = false;
    private int _score = 0;
    
    public ICommand RestartCommand { get; }
    
    public InfinityRaceViewModel()
    {
        RestartCommand = new RestartCommand(RestartGame);
    }
    
    private void RestartGame()
    {
        GameResult = null;
        _score = 0;
        _started = false;
        TimerText = $"{DrawDuration:F0}s";
        IsPreviewVisible = true;

        Restart?.Invoke();
        _startTime = DateTime.Now;
        _waitTimer.Start();
    }

    public event Action DrawingStarted;
    public event Action DrawingEnded;
    public event Action Restart;

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
    
    public GameResult GameResult
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsGameResultVisible));
        }
    }
    
    public bool IsGameResultVisible => GameResult != null;

    public void Initialize(List<Circle> circles, double middle)
    {
        var session = new InfinityRaceSession(circles, middle);
        _service = new InfinityRaceService(session);
        
        _startTime = DateTime.Now;
        _waitTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 100),
            DispatcherPriority.Background, TickWaitTimer, Dispatcher.CurrentDispatcher);

        _drawTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 100),
            DispatcherPriority.Background, TickDrawTimer, Dispatcher.CurrentDispatcher);
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
        {
            WaitTimerText = "START";
        }
        if (timeLeft <= 0)
        {
            _waitTimer.Stop();
            StartDrawPhase();
        }
    }
    
    public void ProcessFinishedDrawing(List<List<StrokePointDto>> strokes)
    {
        foreach (var stroke in strokes)
        {
            var domainStroke = stroke
                .Select(p => new StrokePoint(p.X, p.Y, p.Pressure))
                .ToList();

            _service.AddStroke(domainStroke);
        }

        _score = _service.GetScore();
        TimerText = $"Score: {_score.ToString()}";
        
        GameResult = new GameResult { Score = _score };
    }
}