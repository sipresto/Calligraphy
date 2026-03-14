namespace Calligraphy.Domain.TraceTemplates.RepeatingTraces;

public abstract class RepeatingTrace : TraceTemplate
{
    public abstract TraceShapeStyle ShapeStyle { get; }
    public virtual TraceJoinStyle PreferredJoinStyle => TraceJoinStyle.Round;
}