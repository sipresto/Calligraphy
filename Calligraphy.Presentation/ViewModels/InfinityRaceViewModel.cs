using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class InfinityRaceViewModel : ViewModelBase
{
    
    
    public void ProcessStroke(
        List<StrokePoint> points,
        List<Circle> circles)
    {
        bool hitForbidden = points.Any(p =>
            circles.Any(c =>
                (p.X - c.X) * (p.X - c.X) +
                (p.Y - c.Y) * (p.Y - c.Y)
                <= c.Radius * c.Radius));

        if (hitForbidden)
        {
            Console.WriteLine("Oei");
        }
        else
        {
            Console.WriteLine("Woooooooo");
        }
    }
}