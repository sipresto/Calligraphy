using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class ShapeDrawService : GenericGameService<ShapeDrawSession>
{
    public void InitializeSession(Shape shape)
    {
        var session = new ShapeDrawSession(shape);
        InitializeSession(session);
    }

    public Shape GetShape()
    {
        return Session.Shape;
    }
}