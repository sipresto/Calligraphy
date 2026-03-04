using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Utility;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public abstract class ShapeDrawViewModel : GameViewModelBase<ShapeDrawService>
{
    public ICommand CheckCommand { get; }
    public event Action Check;
    
    protected ShapeDrawViewModel(ShapeDrawService service)
        : base(service)
    {
        CheckCommand = new RelayCommand(() => Check?.Invoke());
    }
    
    protected override void RestartGame()
    {
        Initialize(Service.GetShape().Name);
        GameResult = null;
        RaiseRestarted();
        IsMascotVisible = false;
    }

    public override void ProcessFinishedDrawing(List<List<StrokePointDto>> strokes)    
    {
        foreach (var stroke in strokes)
        {
            var domainStroke = stroke
                .Select(p => new StrokePoint(p.X, p.Y))
                .ToList();

            Service.AddStroke(domainStroke);
        }
        OnGameFinished();
    }
    
    protected override void OnGameFinished()
    {
        var (score, stars) = Service.GetScoreAndStars(new StarThresholds(30, 60, 90));

        MascotMessage = GetStarMessage(stars);
        
        IsMascotVisible = true;
        
        GameResult = new GameResult { Score = score, StarCount = stars };
    }
    

    public List<List<StrokePoint>> GetCurrentTemplateShape(double w, double h)
    {
        return Service.GetShape().GetStrokes(w, h);
    }

    public void Initialize(string shapeName)
    {
        var shape = ShapeFactory.GetShape(shapeName);
        Service.InitializeSession(shape);
    }
}