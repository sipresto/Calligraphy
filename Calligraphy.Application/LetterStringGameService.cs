using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class LetterStringGameService : GenericGameService<WordGameSession>
{
    public LetterStringGameService(IRepository repository) : base(repository)
    {
    }
 
    public void StartSession(string gameId, double toleranceDistance, double requiredAccuracy)
    {
        Initialize(gameId, () => new WordGameSession(toleranceDistance, requiredAccuracy));
    }
 
    public void AddLetter(string name, List<StrokePoint> templatePoints, List<StrokePoint> userPoints)
    {
        Session.AddLetter(name, templatePoints, userPoints);
    }
}