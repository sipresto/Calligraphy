using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class ShapeDrawService : GenericGameService<ShapeDrawSession>
{
    public ShapeDrawService(IRepository repository) : base(repository)
    {
    }

    public void StartSession(string gameId, Shape shape)
    {
        Initialize(gameId, () => new ShapeDrawSession(shape));
    }
}