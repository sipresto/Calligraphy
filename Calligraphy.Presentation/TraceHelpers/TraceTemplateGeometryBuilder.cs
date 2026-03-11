using System.Windows;
using System.Windows.Media;
using Calligraphy.Domain.TraceTemplates;

namespace Calligraphy.Presentation.TraceHelpers;
public class TraceTemplateGeometryBuilder
{
    // ORIGINAL HOP PATTERN
    public static PathFigure BuildHopFigure(TraceTemplateMetadata data)
    {
        var figure = new PathFigure { StartPoint = new Point(data.StartX, data.BaselineY) };
        double x = data.StartX;
        for (int i = 0; i < data.LoopCount; i++)
        {
            figure.Segments.Add(new BezierSegment(
                new Point(x, data.BaselineY - 30),
                new Point(x + data.LoopWidth * 0.2, data.TopY),
                new Point(x + data.LoopWidth * 0.5, data.TopY), true));

            figure.Segments.Add(new BezierSegment(
                new Point(x + data.LoopWidth * 0.8, data.TopY),
                new Point(x + data.LoopWidth, data.BaselineY - 30),
                new Point(x + data.LoopWidth, data.BaselineY), true));
            x += data.LoopWidth;
        }
        return figure;
    }

    // NEW CASTLE WALL PATTERN
    public static PathFigure BuildCastleWallFigure(TraceTemplateMetadata data)
    {
        var figure = new PathFigure { StartPoint = new Point(data.StartX, data.BaselineY) };
        double x = data.StartX;
        for (int i = 0; i < data.LoopCount; i++)
        {
            figure.Segments.Add(new LineSegment(new Point(x, data.TopY), true));
            figure.Segments.Add(new LineSegment(new Point(x + data.LoopWidth * 0.5, data.TopY), true));
            figure.Segments.Add(new LineSegment(new Point(x + data.LoopWidth * 0.5, data.BaselineY), true));
            figure.Segments.Add(new LineSegment(new Point(x + data.LoopWidth, data.BaselineY), true));
            x += data.LoopWidth;
        }
        return figure;
    }
}