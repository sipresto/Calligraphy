namespace Calligraphy.Domain;

public interface ISession
{
    //public IReadOnlyList<IReadOnlyList<StrokePoint>> GetStrokes();

    public void AddStrokes(List<List<StrokePoint>> strokes);

    public int CalculateStars(int score);
}