using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class InfinityRaceView : UserControl
{
    public InfinityRaceView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
        InkCanvas.StrokeCompleted += OnStrokeCompleted;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        List<Circle> circles = GetCircleData();
        double middle = InkCanvas.ActualWidth / 2;
        
        if (DataContext is InfinityRaceViewModel vm)
        {
            vm.CreateGameSession(circles, middle);
        }
    }

    private void OnStrokeCompleted(List<StrokeDto> points)
    {
        if (DataContext is InfinityRaceViewModel vm)
        {
            vm.AddStroke(points);
        }
    }
    
    private List<Circle> GetCircleData()
    {
        var circles = new List<Circle>
        {
            GetCircleInfo(LeftCircle),
            GetCircleInfo(RightCircle)
        };

        return circles;
    }

    private Circle GetCircleInfo(Ellipse ellipse)
    {
        Point localCenter = new Point(ellipse.Width / 2, ellipse.Height / 2);
        Point canvasCenter = ellipse.TranslatePoint(localCenter, InkCanvas);
        double radius = ellipse.Width / 2;

        return new Circle(canvasCenter.X, canvasCenter.Y, radius);
    }

}