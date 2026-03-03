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

    public override void ProcessFinishedDrawing(List<List<StrokePointDto>> strokes)    
    {
        foreach (var stroke in strokes)
        {
            var domainStroke = stroke
                .Select(p => new StrokePoint(p.X, p.Y))
                .ToList();

            _service.AddStroke(domainStroke);
        }
    }
    
    protected override void OnGameFinished()
    {
        var (score, stars) = _service.CheckShape();

        MascotMessage = GetStarMessage(stars);
        
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