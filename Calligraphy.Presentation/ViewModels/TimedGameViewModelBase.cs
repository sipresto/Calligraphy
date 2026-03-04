using System.Windows.Threading;

namespace Calligraphy.Presentation.ViewModels;

public abstract class TimedGameViewModelBase<TService> : GameViewModelBase<TService>
{
    private DispatcherTimer _drawTimer;
    private DispatcherTimer _waitTimer;
    private DateTime _startTime;
    private bool _started;

    private int DrawDuration { get; init; }
    private int WaitDuration { get; init; }

    public string TimerText
    {
        get;
        protected set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public string WaitTimerText
    {
        get;
        protected set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool IsPreviewVisible
    {
        get;
        protected set
        {
            field = value;
            OnPropertyChanged();
        }
    } = true;

    public event Action DrawingStarted;
    public event Action DrawingEnded;

    protected TimedGameViewModelBase(TService service, int drawDuration, int waitDuration = 3)
        : base(service)
    {
        DrawDuration = drawDuration;
        WaitDuration = waitDuration;

        TimerText = $"{DrawDuration:F0}s";
        WaitTimerText = $"{WaitDuration:F0}";

        InitializeTimers();
    }

    private void InitializeTimers()
    {
        _drawTimer = new DispatcherTimer(
            TimeSpan.FromMilliseconds(100),
            DispatcherPriority.Background,
            TickDrawTimer,
            Dispatcher.CurrentDispatcher);

        _waitTimer = new DispatcherTimer(
            TimeSpan.FromMilliseconds(100),
            DispatcherPriority.Background,
            TickWaitTimer,
            Dispatcher.CurrentDispatcher);
    }

    protected void StartWaitPhase()
    {
        _startTime = DateTime.Now;
        _waitTimer.Start();
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
        TimerText = $"{Math.Max(0, timeLeft):F0}s";

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
        WaitTimerText = timeLeft < 1 ? "START" : $"{timeLeft:F0}";

        if (timeLeft <= 0)
        {
            _waitTimer.Stop();
            StartDrawPhase();
        }
    }

    protected override void RestartGame()
    {
        GameResult = null;
        _started = false;
        TimerText = $"{DrawDuration:F0}s";
        WaitTimerText = $"{WaitDuration:F0}";
        IsPreviewVisible = true;

        OnRestart();
        StartWaitPhase();
    }
    
    protected abstract void OnRestart();
}