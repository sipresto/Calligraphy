using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : TimedGameViewModelBase<InfinityRaceService, InfinityRaceSession, InfinityRaceSettings>
{
    public InfinityRaceViewModel(InfinityRaceService service, GameSettings settings)
        : base(service, settings)
    {
    }

    public void Initialize(List<RaceCircle> circles)
    {
        Settings = AllSettings.InfinityRace;
        Service.InitializeSession(circles);
        StartWaitPhase();
    }
}