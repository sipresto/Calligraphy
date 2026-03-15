using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : TimedGameViewModelBase<InfinityRaceService, InfinityRaceSession, InfinityRaceSettings>
{
    private const string GameId = "InfinityRace";
    private List<RaceCircle> _circles;
    
    public InfinityRaceViewModel(InfinityRaceService service, MainViewModel mainViewModel, GameSettings settings)
        : base(service, mainViewModel, settings)
    {
        Settings = AllSettings.InfinityRace;
    }

    public void Initialize(List<RaceCircle> circles)
    {
        _circles = circles;
        LoadBestScore(GameId);
        Service.InitializeSession(GameId, _circles);
        StartWaitPhase();
    }
    
    protected override void RestartGame()
    {
        Service.InitializeSession(GameId, _circles);
        LoadBestScore(GameId);
        base.RestartGame(); 
    }
}