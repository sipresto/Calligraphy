using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.Utility;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : GameViewModelBase<ShapeDrawService, ShapeDrawSession>
{
    public event Action Check;
    
    public ICommand CheckCommand { get; }
    
    public ShapeDrawViewModel(ShapeDrawService service)
        : base(service)
    {
        CheckCommand = new RelayCommand(() => Check?.Invoke());
    }
    
    public void Initialize(double dpi, string shapeName)
    {
        var shape = ShapeFactory.GetShape(shapeName);
        Service.InitializeSession(dpi, shape);
    }
    
    public List<List<StrokePoint>> GetCurrentTemplateShape(double w, double h)
    {
        return Service.GetShape().GetStrokes(w, h);
    }
    
    protected override void RestartGame()
    {
        ResetGameState();
    }
}