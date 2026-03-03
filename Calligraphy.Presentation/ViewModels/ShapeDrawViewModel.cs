using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : ViewModelBase
{
    private readonly ShapeDrawService _service;
    public ICommand ResetCommand { get; }
    public event Action Reset;
    public ICommand CheckCommand { get; }
    public event Action Check;

    public ShapeDrawViewModel(ShapeDrawService service)
    {
        _service = service;
        ResetCommand = new RelayCommand(ResetGame);
        CheckCommand = new RelayCommand(() =>
            {
                Check?.Invoke();
            });
    }
    
    public void ResetGame()
    {
        Initialize(_service.GetShape().Name);
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
    
    public (bool Success, string Message) CheckGame()
    {
        var (success, score) = _service.CheckShape();

        if (success)
            return (true, $"Correct! Score: {score:P0}");
        else
            return (false, $"Try again. Score: {score:P0}");
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