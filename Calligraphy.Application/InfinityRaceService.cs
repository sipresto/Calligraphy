using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class InfinityRaceService(FeedbackMessageProvider feedbackMessageProvider)
    : GenericGameService<InfinityRaceSession>(feedbackMessageProvider)
{
    public void InitializeSession(List<Circle> circles, double dpi)
    {
        var session = new InfinityRaceSession(circles);
        InitializeSession(session, dpi);
    }
}