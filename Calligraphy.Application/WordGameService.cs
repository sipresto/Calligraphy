using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class WordGameService : GenericGameService<WordGameSession>
{
    public WordGameService(IRepository repository) : base(repository)
    {
    }
    
    public void StartSession(string gameId, List<string> words)
    {
        Initialize(gameId, () => new WordGameSession(words));
    }
}