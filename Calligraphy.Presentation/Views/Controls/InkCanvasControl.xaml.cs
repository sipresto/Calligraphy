using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using Calligraphy.Presentation.ColorHandling;
using Calligraphy.Presentation.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation.Views.Controls;

public partial class InkCanvasControl : UserControl
{
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
    private List<StrokePointDto> _liveStroke = [];
    private List<List<StrokePointDto>> _strokes = [];

    public static readonly DependencyProperty IsDrawingEnabledProperty =
        DependencyProperty.Register(
            nameof(IsDrawingEnabled),
            typeof(bool),
            typeof(InkCanvasControl),
            new PropertyMetadata(false, OnIsDrawingEnabledChanged));
    
    public InkCanvasControl()
    {
        InitializeComponent();
        CallyCanvas.EditingMode = InkCanvasEditingMode.Ink;
        CallyCanvas.EditingModeInverted = InkCanvasEditingMode.None;

        CallyCanvas.AddHandler(PreviewMouseDownEvent, new MouseButtonEventHandler(SuppressMouseEvent), handledEventsToo: true);
        CallyCanvas.AddHandler(PreviewMouseMoveEvent, new MouseEventHandler(SuppressMouseMoveEvent), handledEventsToo: true);
        CallyCanvas.AddHandler(PreviewMouseUpEvent, new MouseButtonEventHandler(SuppressMouseEvent), handledEventsToo: true);

        Loaded += InkCanvasControl_Loaded;
    }
    
    private void SuppressMouseEvent(object sender, MouseButtonEventArgs e)
    {
        if (e.StylusDevice == null)
            e.Handled = true;
    }

    private void SuppressMouseMoveEvent(object sender, MouseEventArgs e)
    {
        if (e.StylusDevice == null)
            e.Handled = true;
    }
    
    public bool IsDrawingEnabled
    {
        get => (bool)GetValue(IsDrawingEnabledProperty);
        set => SetValue(IsDrawingEnabledProperty, value);
    }
    
    public event Action StylusUp;
    
    private static void OnIsDrawingEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is InkCanvasControl control)
            control.CallyCanvas.IsEnabled = (bool)e.NewValue;
    }

    private void InkCanvasControl_Loaded(object sender, RoutedEventArgs e)
    {
        var drawingState = App.ServiceProvider.GetRequiredService<DrawingState>();

        if (drawingState.PenColor is SolidColorBrush initialBrush)
            CallyCanvas.DefaultDrawingAttributes.Color = initialBrush.Color;

        drawingState.PropertyChanged += (s, args) =>
        {
            if (args.PropertyName == nameof(DrawingState.PenColor)
                && drawingState.PenColor is SolidColorBrush brush)
                CallyCanvas.DefaultDrawingAttributes.Color = brush.Color;
        };
    }

    public List<List<StrokePointDto>> EndDrawing(bool disableDrawing = true)
    {
        if (disableDrawing)
            CallyCanvas.IsEnabled = false;

        if (_liveStroke.Count > 0)
        {
            _strokes.Add(_liveStroke);
        }

        DisplayStoredStrokes(_strokes);

        var finishedStrokes = _strokes;
        _strokes = [];
        _liveStroke = [];
        return finishedStrokes;
    }

    public void SetDrawingEnabled(bool enabled)
    {
        CallyCanvas.IsEnabled = enabled;
    }

    public void Clear(bool enableDrawing = false)
    {
        _strokes = [];
        _liveStroke = [];
        CallyCanvas.Strokes.Clear();
        CallyCanvas.IsEnabled = enableDrawing;
    }

    private void CallyCanvas_StylusMove(object sender, StylusEventArgs e)
    {
        StylusPointCollection points = e.GetStylusPoints(CallyCanvas);

        foreach (var point in points)
        {
            var strokePoint = new StrokePointDto(
                point.X,
                point.Y,
                point.PressureFactor,
                _stopwatch.ElapsedMilliseconds
            );

            _liveStroke.Add(strokePoint);
        }
    }

    private void CallyCanvas_StylusUp(object sender, StylusEventArgs e)
    {
        _strokes.Add(_liveStroke);
        _liveStroke = [];
        StylusUp?.Invoke();
    }

    private void DisplayStoredStrokes(List<List<StrokePointDto>> strokes)
    {
        CallyCanvas.Strokes.Clear();

        var drawingState = App.ServiceProvider.GetRequiredService<DrawingState>();
        var color = drawingState.PenColor is SolidColorBrush brush ? brush.Color : Colors.Black;

        foreach (var stroke in strokes)
        {
            if (stroke == null || stroke.Count == 0) continue;

            var stylusPoints = new StylusPointCollection(
                stroke.Select(p => new StylusPoint(p.X, p.Y, p.Pressure))
            );

            var newStroke = new Stroke(stylusPoints);
            newStroke.DrawingAttributes.Color = color;
            CallyCanvas.Strokes.Add(newStroke);
        }
    }
}