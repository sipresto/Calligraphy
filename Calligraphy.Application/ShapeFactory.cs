using Calligraphy.Domain;

namespace Calligraphy.Application;

public static class ShapeFactory
{
    public static Shape GetShape(string name) => name switch
    {
        "Triangle" => new Triangle(),
        "Circle"   => new CircleShape(),
        "Star"     => new Star(),
        "Pentagon" => new Pentagon(),
        "Hexagon"  => new Hexagon(),
        "Diamond"  => new Diamond(),
        _          => new Square()
    };
}