namespace Calligraphy.Application;

public class HandwritingSession
{
    public string SessionId { get; set; } = Guid.NewGuid().ToString();
    public string TargetLetter { get; set; } = "";
    public List<StrokePoint> Points { get; set; } = new();
}