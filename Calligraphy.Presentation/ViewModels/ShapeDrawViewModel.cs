using Calligraphy.Application;
using Calligraphy.Domain;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : ViewModelBase
{
    private readonly ShapeDrawService _service;
    private readonly string _shapeName;
    

    public ShapeDrawViewModel(string shapeName)
    {
        _shapeName = shapeName;
        _service = new ShapeDrawService();
        _service.InitializeSession(shapeName);
    }
    
    public void Reset()
    {
        _service.Reset();
    }

    
    public (bool Success, string Message) Check(double w, double h)
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