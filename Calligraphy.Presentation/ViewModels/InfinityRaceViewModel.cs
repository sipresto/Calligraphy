using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : ViewModelBase
{
    private InfinityRaceService _service;

    public void CreateGameSession(List<Circle> circles, double middle)
    {
        var session = new InfinityRaceSession(circles, middle);
        _service = new InfinityRaceService(session);
    }

    public void AddStroke(List<StrokeDto> points)
    {
        List<StrokePoint> domainPoints = points
            .Select(p => new StrokePoint(p.X, p.Y, p.Pressure))
            .ToList();

        _service.AddStroke(domainPoints);
    }

    public int Score { get; private set; }
}