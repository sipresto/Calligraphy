namespace Calligraphy.Domain;

public class RaceCircle
{
    private readonly double _x;
    private readonly double _y;
    private readonly double _radius;

    public RaceCircle(double x, double y, double radius)
    {
        _x = x;
        _y = y;
        _radius = radius;
    }

    public bool IsAbove(double y) => y < _y - _radius;
    public bool IsBelow(double y) => y > _y + _radius;
    public bool IsLeftOf(double x) => x < _x - _radius;
    public bool IsRightOf(double x) => x > _x + _radius;

    public bool IsInside(double x, double y)
        => (x - _x) * (x - _x) + (y - _y) * (y - _y) <= _radius * _radius;
}