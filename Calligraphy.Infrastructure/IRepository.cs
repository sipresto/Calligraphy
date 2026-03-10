using Calligraphy.Domain;

namespace Calligraphy.Infrastructure;

public interface IRepository
{
    public void Save(GameResultRecord record);
    
    public GameResultRecord Get(string gameName);
}