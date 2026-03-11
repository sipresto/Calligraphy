using Calligraphy.Domain.TraceTemplates;

namespace Calligraphy.Domain.Utility;

public static class TraceFactory
{
    public static TraceTemplate GetTraceTemplate(string name)
    {
        var type = typeof(TraceTemplate).Assembly.GetTypes()
            .FirstOrDefault(t => t.Name == name && typeof(TraceTemplate).IsAssignableFrom(t));

        return type != null ? (TraceTemplate)Activator.CreateInstance(type) : new WavePattern();
    }
}