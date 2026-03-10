using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.Utility;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class ShapeDrawViewModel : GameViewModelBase<ShapeDrawService, ShapeDrawSession, ShapeGameSettings>
{
    private string _gameId;
    
    public ShapeDrawViewModel(ShapeDrawService service, GameSettings settings)
        : base(service, settings)
    {
        CheckCommand = new RelayCommand(() => Check?.Invoke());
    }

    public ICommand CheckCommand { get; }
    public event Action Check;

    private Shape CurrentShape { get; set; }

    public void Initialize(string gameId)
    {
        _gameId = gameId;
        Settings = AllSettings.ShapeGames[gameId];
        CurrentShape = ShapeFactory.GetShape(Settings.Shape);
        Service.InitializeSession(_gameId, CurrentShape);
    }

    public List<List<StrokePoint>> GetCurrentTemplateShape(double w, double h)
    {
        return CurrentShape.GetStrokes(w, h);
    }

    protected override void RestartGame()
    {
        Service.InitializeSession(_gameId, CurrentShape);
        ResetGameState();
    }
}