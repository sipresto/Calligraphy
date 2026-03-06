using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : TimedGameViewModelBase<InfinityRaceService, InfinityRaceSession, InfinityRaceSettings>
{
    private List<RaceCircle> _circles;
    
    public InfinityRaceViewModel(InfinityRaceService service, GameSettings settings)
        : base(service, settings)
    {
        Settings = AllSettings.InfinityRace;
    }

    public void Initialize(List<RaceCircle> circles)
    {
        _circles = circles;
        Service.InitializeSession(_circles);
        StartWaitPhase();
    }
    
    protected override void RestartGame()
    {
        Service.InitializeSession(_circles);
        base.RestartGame(); 
    }
}