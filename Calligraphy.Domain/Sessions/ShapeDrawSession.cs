using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class ShapeDrawSession : GameSession
{
    public Shape Shape { get; }

    public ShapeDrawSession(Shape shape)
    {
        Shape = shape;
    }

    public override int CalculateScore()
    {
        double accuracy = Recognizer.CalculateAccuracy(TotalStroke(), Shape.Name);

        double threshold = Shape.Name switch
        {
            "Circle" => 0.45,
            "Square" => 0.42,
            "Triangle" => 0.40,
            "Diamond" => 0.40,
            "Star" => 0.38,
            "Pentagon" => 0.40,
            "Hexagon" => 0.40,
            _ => 0.40
        };

        return accuracy >= threshold
            ? (int)Math.Round(accuracy * 100)
            : 0;
    }
}