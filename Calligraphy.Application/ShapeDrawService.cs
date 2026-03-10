using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;
using Calligraphy.Infrastructure;

namespace Calligraphy.Application;

public class ShapeDrawService : GenericGameService<ShapeDrawSession>
{
    public ShapeDrawService(IRepository repository) : base(repository)
    {
    }

    public void InitializeSession(string gameId, Shape shape)
    {
        var session = new ShapeDrawSession(shape);
        InitializeSession(session, gameId);
    }

    public Shape GetShape()
    {
        return Session.Shape;
    }
}