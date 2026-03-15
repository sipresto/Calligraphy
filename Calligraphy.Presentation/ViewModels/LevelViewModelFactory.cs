using Calligraphy.Application;
using Calligraphy.Domain.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation.ViewModels;

public class LevelViewModelFactory
{
    private readonly IServiceProvider _services;
 
    public LevelViewModelFactory(IServiceProvider services)
    {
        _services = services;
    }
 
    public LevelViewModel CreateLevelViewModel(string category)
    {
        return new LevelViewModel(
            _services.GetRequiredService<MainViewModel>(),
            _services.GetRequiredService<InfinityRaceService>(),
            _services.GetRequiredService<TraceGameService>(),
            _services.GetRequiredService<ShapeDrawService>(),
            _services.GetRequiredService<GameSettings>(),
            category);
    }
}