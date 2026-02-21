using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class InfinityRaceView : UserControl
{
    private InfinityRaceViewModel ViewModel =>
        DataContext as InfinityRaceViewModel;
    
    public InfinityRaceView()
    {
        InitializeComponent();
        
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        List<Circle> circles = GetCircleData();
        double middle = InkCanvas.ActualWidth / 2;
        
        ViewModel?.Initialize(circles, middle);
        ViewModel?.DrawingEnded += OnDrawingEnded;
    }
    
    private void OnDrawingEnded()
    {
        var strokes = InkCanvas.EndDrawing();

        ViewModel?.ProcessFinishedDrawing(strokes);
    }
    
    private List<Circle> GetCircleData()
    {
        return [GetCircleInfo(LeftCircle), GetCircleInfo(RightCircle)];
    }

    private Circle GetCircleInfo(Ellipse ellipse)
    {
        Point localCenter = new Point(ellipse.Width / 2, ellipse.Height / 2);
        Point canvasCenter = ellipse.TranslatePoint(localCenter, InkCanvas);
        double radius = ellipse.Width / 2;

        return new Circle(canvasCenter.X, canvasCenter.Y, radius);
    }
}