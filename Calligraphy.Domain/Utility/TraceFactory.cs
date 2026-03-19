using Calligraphy.Domain.TraceTemplates;

namespace Calligraphy.Domain.Utility;

public static class TraceFactory
{
    public static TraceTemplate GetTraceTemplate(string name)
    {
        var type = typeof(TraceTemplate).Assembly.GetTypes()
            .FirstOrDefault(t => t.Name == name && typeof(TraceTemplate).IsAssignableFrom(t));

        return type != null
            ? (TraceTemplate)Activator.CreateInstance(type)
            : throw new InvalidOperationException($"No TraceTemplate found for '{name}'");
    }

    public static TraceTemplate GetTraceTemplateByLetter(char letter)
    {
        string className = $"Lowercase{char.ToUpper(letter)}";

        try
        {
            return GetTraceTemplate(className);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException(
                $"No trace template class found for the letter '{letter}' (Expected class: {className})");
        }
    }
}