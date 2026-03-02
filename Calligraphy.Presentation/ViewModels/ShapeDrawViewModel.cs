using System.Windows;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Recognition;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : ViewModelBase
{
    private readonly ShapeDrawService _service;
    private readonly string _shapeName;
    public ShapeDrawSession Session { get; }
    

    public ShapeDrawViewModel(string shapeName)
    {
        Session = new ShapeDrawSession(shapeName);
        _shapeName = shapeName;
        _service = new ShapeDrawService();
    }

    public void InitializeTemplates(double w, double h)
    {
        _service.LoadTemplates(w, h);
    }

    public void Reset()
    {
        Session.Reset();
    }

    public void StartStroke()
    {
        Session.AddStroke(new List<StrokePoint>());
    }
    
    public (bool Success, string Message) Check(double w, double h)
    {
        var (success, score) = _service.CheckShape(Session, w, h);

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