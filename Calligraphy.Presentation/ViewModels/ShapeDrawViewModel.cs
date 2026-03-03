using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : GameViewModelBase
{
    private readonly ShapeDrawService _service;
    public ICommand RestartCommand { get; }
    public event Action Reset;
    public ICommand CheckCommand { get; }
    public event Action Check;
    
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

    public ShapeDrawViewModel(ShapeDrawService service)
    {
        _service = service;
        RestartCommand = new RelayCommand(RestartGame);
        CheckCommand = new RelayCommand(() => Check?.Invoke());
    }
    
    protected override void RestartGame()
    {
        Initialize(_service.GetShape().Name);
        GameResult = null;
        Reset?.Invoke();
    }

    public void AddStrokes(List<List<StrokePointDto>> points)
    {
        List<List<StrokePoint>> strokepoints = new List<List<StrokePoint>>();
        foreach (var point in points)
        {
            List<StrokePoint> strokepoint = new List<StrokePoint>();
            foreach (var strokePointDto in point)
            {
                strokepoint.Add(new StrokePoint(strokePointDto.X, strokePointDto.Y, strokePointDto.Pressure, strokePointDto.Timestamp));
            }
            strokepoints.Add(strokepoint);
        }
        
        _service.AddStrokes(strokepoints);
    }
    
    public void CheckGame()
    {
        var (success, score, stars) = _service.CheckShape();

        MascotMessage = stars switch
        {
            3 => "Geweldig! Je het heel goed gedaan",
            2 => "Goed gedaan! Het was al bijna perfect",
            1 => "Niet slecht! Probeer het nog eens en kijk of je meer punten kunt halen",
            0 => "Blijf oefenen! Je kunt het beter doen als je het nog eens probeert",
            _ => ""
        };
        
        IsMascotVisible = true;
        
        GameResult = new GameResult { Score = (int)score, StarCount = stars };
    }

    public List<List<StrokePoint>> GetCurrentTemplateShape(double w, double h)
    {
        return _service.GetShape().GetStrokes(w, h);
    }

    public void Initialize(string shapeName)
    {
        var shape = ShapeFactory.GetShape(shapeName);
        _service.InitializeSession(shape);
    }
}