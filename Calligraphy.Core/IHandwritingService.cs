namespace Calligraphy.Core;

public interface IHandwritingService
{
    Task<bool> SubmitSessionAsync(HandwritingSession session);
}