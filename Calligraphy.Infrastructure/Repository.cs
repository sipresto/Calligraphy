using Calligraphy.Domain;

namespace Calligraphy.Infrastructure;

public class Repository(CallyDbContext context) : IRepository
{
    public void Save(GameResultRecord record)
    {
        GameResultRecord existing = Get(record.GameId);

        if (existing != null)
        {
            context.GameResultRecords.Remove(existing);
        }

        context.GameResultRecords.Add(record);

        context.SaveChanges();
    }

    public GameResultRecord Get(string gameId)
    {
        return context.GameResultRecords
            .SingleOrDefault(r => r.GameId == gameId);
    }
}