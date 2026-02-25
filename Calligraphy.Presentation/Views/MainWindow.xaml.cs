using System.Windows;
using Calligraphy.Application.Recognition;

namespace Calligraphy.Presentation.Views;

public partial class MainWindow : Window
{
    private readonly IShapeRecognitionService _recognizer;

    public MainWindow()
    {
        InitializeComponent();
        _recognizer = new ShapeRecognitionService();

    }
}