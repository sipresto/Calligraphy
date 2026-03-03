using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Commands;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : ViewModelBase
{
    private readonly ShapeDrawService _service;
    private readonly string _shapeName;
    public ICommand ResetCommand { get; }
    public event Action Reset;
    public ICommand CheckCommand { get; }
    public event Action Check;

    public ShapeDrawViewModel(string shapeName)
    {
        _shapeName = shapeName;
        _service = new ShapeDrawService();
        _service.InitializeSession(shapeName);
        ResetCommand = new ResetCommand(ResetGame);
        CheckCommand = new CheckCommand(() =>
            {
                Check?.Invoke();
            });
    }
    
    public string ResultMessage
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    }
    
    public void ResetGame()
    {
        _service.Reset();
        Reset?.Invoke();
    }

    public void AddStroke(List<StrokePoint> points)
    {
        _service.AddStroke(points);
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
}