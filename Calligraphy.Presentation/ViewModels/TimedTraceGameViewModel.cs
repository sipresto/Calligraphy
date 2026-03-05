using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.Utility;

namespace Calligraphy.Presentation.ViewModels;

public class TimedTraceGameViewModel : TimedGameViewModelBase<TraceGameService, TraceGameSession>
{
    public const double StartX = 80;
    public const double BaselineY = 450;
    public const double TopY = 290;
    public const double LoopWidth = 110;
    public const int LoopCount = 9;
    private const int PointsPerLoop = 100; //higher for more points to trace
    
    private readonly List<StrokePoint> _templatePoints;

    public TimedTraceGameViewModel(TraceGameService service)
        : base(service, 30)
    {
        _templatePoints = TraceTemplateGenerator.GenerateHopPattern(
            StartX,
            BaselineY,
            TopY,
            LoopWidth,
            LoopCount,
            PointsPerLoop);
    }

    public void Initialize(double dpi)
    {
        Service.InitializeSession(dpi, _templatePoints, 30.0);
    }
}