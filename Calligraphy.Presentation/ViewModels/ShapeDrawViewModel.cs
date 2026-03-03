using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Commands;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : ViewModelBase
{
    private readonly ShapeDrawService _service;
    private string _shapeName;
    public ICommand ResetCommand { get; }
    public event Action Reset;
    public ICommand CheckCommand { get; }
    public event Action Check;

    public ShapeDrawViewModel(ShapeDrawService service)
    {
        _service = service;
        ResetCommand = new ResetCommand(ResetGame);
        CheckCommand = new CheckCommand(() =>
            {
                Check?.Invoke();
            });
    }
    
    public void ResetGame()
    {
        _service.Reset();
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
        var (success, score) = _service.CheckShape(_shapeName);

        if (success)
            return (true, $"Correct! Score: {score:P0}");
        else
            return (false, $"Try again. Score: {score:P0}");
    }

    public List<List<StrokePoint>> GetCurrentTemplateShape(double w, double h)
    {
        return ShapeFactory.GetShape(
            _shapeName,
            w,
            h);
    }

    public void Initialize(string shape)
    {
        _shapeName = shape;
        _service.InitializeSession(shape);
    }
}