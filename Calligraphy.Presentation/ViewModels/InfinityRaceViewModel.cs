using System.Windows.Threading;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : ViewModelBase
{
    private InfinityRaceService _service;
    private DispatcherTimer _timer;
    private DateTime _startTime;
    private bool _started = false;
    
    private const int DrawDuration = 10;

    public event Action DrawingEnded;

    public string TimerText
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    } = "30s";

    private int _score;
    public int Score
    {
        get => _score;
        private set { _score = value; OnPropertyChanged(); }
    }

    public void Initialize(List<Circle> circles, double middle)
    {
        var session = new InfinityRaceSession(circles, middle);
        _service = new InfinityRaceService(session);

        _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 100),
            DispatcherPriority.Background, TickDrawTimer, Dispatcher.CurrentDispatcher);
        
        StartDrawPhase();
    }

    private void StartDrawPhase()
    {
        _startTime = DateTime.Now;
        _timer.Start();
        _started = true;
    }

    private void TickDrawTimer(object sender, EventArgs e)
    {
        if (!_started) return;
        var timeLeft = DrawDuration - (DateTime.Now - _startTime).TotalSeconds;
        TimerText = $"{timeLeft:F0}s";

        if (timeLeft <= 0)
        {
            _timer.Stop();
            TimerText = "0.0s";
            DrawingEnded?.Invoke();
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

        Score = _service.GetScore();
        Console.WriteLine(Score);
    }
}