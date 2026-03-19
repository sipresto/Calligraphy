using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class WordGameService : GenericGameService<WordGameSession>
{
    public WordGameService(IRepository repository) : base(repository)
    {
    }
    
    public void StartSession(string gameId, List<string> words, double toleranceDistance, double requiredAccuracy)
    {
        Initialize(gameId, () => new WordGameSession(words, toleranceDistance, requiredAccuracy));
    }

    public void AddLetter(List<StrokePoint> templatePoints, List<StrokePoint> userPoints)
    {
        Session.AddLetter(templatePoints, userPoints);
    }
}