using System.Windows;
using System.Windows.Media;
using Calligraphy.Domain.TraceTemplates;

namespace Calligraphy.Presentation.TraceHelpers;
public class TraceTemplateGeometryBuilder
{
    //WAVE & HEDGE PATTERN
    public static PathFigure BuildHopFigure(TraceTemplateMetadata data)
    {
        var figure = new PathFigure { StartPoint = new Point(data.StartX, data.BaselineY) };
        double x = data.StartX;
        for (int i = 0; i < data.RepeatCount; i++)
        {
            figure.Segments.Add(new BezierSegment(
                new Point(x, data.BaselineY - 30),
                new Point(x + data.UnitWidth * 0.2, data.CapHeightY),
                new Point(x + data.UnitWidth * 0.5, data.CapHeightY), true));

            figure.Segments.Add(new BezierSegment(
                new Point(x + data.UnitWidth * 0.8, data.CapHeightY),
                new Point(x + data.UnitWidth, data.BaselineY - 30),
                new Point(x + data.UnitWidth, data.BaselineY), true));
            x += data.UnitWidth;
        }
        return figure;
    }

    //CASTLE WALL PATTERN
    public static PathFigure BuildCastleWallFigure(TraceTemplateMetadata data)
    {
        var figure = new PathFigure { StartPoint = new Point(data.StartX, data.BaselineY) };
        double x = data.StartX;
        for (int i = 0; i < data.RepeatCount; i++)
        {
            figure.Segments.Add(new LineSegment(new Point(x, data.CapHeightY), true));
            figure.Segments.Add(new LineSegment(new Point(x + data.UnitWidth * 0.5, data.CapHeightY), true));
            figure.Segments.Add(new LineSegment(new Point(x + data.UnitWidth * 0.5, data.BaselineY), true));
            figure.Segments.Add(new LineSegment(new Point(x + data.UnitWidth, data.BaselineY), true));
            x += data.UnitWidth;
        }
        figure.Segments.Add(new LineSegment(new Point(x, data.CapHeightY), true));
        figure.Segments.Add(new LineSegment(new Point(x + data.UnitWidth * 0.5, data.CapHeightY), true));
        figure.Segments.Add(new LineSegment(new Point(x + data.UnitWidth * 0.5, data.BaselineY), true));
        return figure;
    }
    
    //LOOP PATTERN
    public static PathFigure BuildLoopFigure(TraceTemplateMetadata data)
    {
        var figure = new PathFigure { StartPoint = new Point(data.StartX, data.BaselineY) };
        double x = data.StartX;
        double height = data.BaselineY - data.CapHeightY;

        for (int i = 0; i < data.RepeatCount; i++)
        {

            Point cp1 = new Point(x + data.UnitWidth * 0.7, data.BaselineY);
            Point cp2 = new Point(x + data.UnitWidth * 0.9, data.CapHeightY);
            Point endPoint = new Point(x + data.UnitWidth * 0.5, data.CapHeightY);

            figure.Segments.Add(new BezierSegment(cp1, cp2, endPoint, true));

            Point cp3 = new Point(x + data.UnitWidth * 0.1, data.CapHeightY);
            Point cp4 = new Point(x + data.UnitWidth * 0.3, data.BaselineY);
            Point nextStart = new Point(x + data.UnitWidth, data.BaselineY);

            figure.Segments.Add(new BezierSegment(cp3, cp4, nextStart, true));

            x += data.UnitWidth;
        }

        return figure;
    }
}