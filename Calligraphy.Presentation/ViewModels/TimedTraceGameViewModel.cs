using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.TraceTemplates;

namespace Calligraphy.Presentation.ViewModels;

public class TimedTraceGameViewModel : TimedGameViewModelBase<TraceGameService, TraceGameSession>
{
    public const double StartX = 80;
    public const double BaselineY = 450;
    public const double TopY = 290;
    public const double LoopWidth = 110;
    public const int LoopCount = 9;
    private const int PointsPerLoop = 100; //higher for more points to trace

    private readonly TraceTemplate _tracePattern;

    public TimedTraceGameViewModel(TraceGameService service)
        : base(service, 30)
    {
        _tracePattern = new HopPattern(
            StartX,
            BaselineY,
            TopY,
            LoopWidth,
            LoopCount,
            PointsPerLoop);
    }

    public void Initialize()
    {
        Service.InitializeSession(_tracePattern.GetTemplatePoints(), 30.0);
        StartWaitPhase();
    }
}