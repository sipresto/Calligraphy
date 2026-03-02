namespace Calligraphy.Domain;

public interface ISession
{
    //public IReadOnlyList<IReadOnlyList<StrokePoint>> GetStrokes();

    public void AddStroke(List<StrokePoint> stroke);

    public int CalculateScore();
}