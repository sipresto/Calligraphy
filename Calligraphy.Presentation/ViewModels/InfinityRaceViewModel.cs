using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : TimedGameViewModelBase<InfinityRaceService, InfinityRaceSession>
{
    // TODO: Magic number
    public InfinityRaceViewModel(InfinityRaceService service, MainViewModel mainViewModel)
        : base(service, mainViewModel, 20)
    {
    }

    public void Initialize(List<RaceCircle> circles)
    {
        Service.InitializeSession(circles);
        StartWaitPhase();
    }
}