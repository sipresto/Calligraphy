using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.Utility;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : GameViewModelBase<ShapeDrawService, ShapeDrawSession>
{
    public ShapeDrawViewModel(ShapeDrawService service, MainViewModel mainViewModel)
        : base(service, mainViewModel)
    {
        CheckCommand = new RelayCommand(() => Check?.Invoke());
    }

    public ICommand CheckCommand { get; }
    public event Action Check;

    public void Initialize(string shapeName)
    {
        var shape = ShapeFactory.GetShape(shapeName);
        Service.InitializeSession(shape);
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