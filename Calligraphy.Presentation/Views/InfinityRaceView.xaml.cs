using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Calligraphy.Presentation.Models;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class InfinityRaceView : UserControl
{
    private List<Circle> _circles = [];
    private double _middle;

    public InfinityRaceView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
        InkCanvas.StrokeCompleted += OnStrokeCompleted;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _circles = GetCircleData();
        _middle = InkCanvas.ActualWidth / 2;
        
    }

    private void OnStrokeCompleted(List<StrokePoint> points)
    {
        if (DataContext is InfinityRaceViewModel vm)
        {
            vm.ProcessStroke(points, _circles);
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