using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Utility;
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
        IsMascotVisible = false;
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
        OnGameFinished();
    }
    
    protected override void OnGameFinished()
    {
        var (score, stars) = _service.GetScoreAndStars(new StarThresholds(30, 60, 90));

        MascotMessage = GetStarMessage(stars);
        
        IsMascotVisible = true;
        
        GameResult = new GameResult { Score = score, StarCount = stars };
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