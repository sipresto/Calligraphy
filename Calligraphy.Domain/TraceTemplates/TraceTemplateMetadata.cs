namespace Calligraphy.Domain.TraceTemplates;

public class TraceTemplateMetadata
{
    //The starting point
    public double StartX { get; init; }
    public double BaselineY { get; init; }
    //Top height of the figure
    public double CapHeightY { get; init; }
    //width of the loop wall etc
    public double UnitWidth { get; init; }
    //how many iterations you want of the figure
    public int RepeatCount { get; init; }
}