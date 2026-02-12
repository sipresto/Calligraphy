namespace Calligraphy.Domain;

public class HandwritingSession
{
    public Guid SessionId { get; set; } = Guid.NewGuid();
    public string TargetLetter { get; set; } = "";
    public List<StrokePoint> Points { get; set; } = new();
}