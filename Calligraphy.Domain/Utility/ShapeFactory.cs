namespace Calligraphy.Domain.Utility;

public static class ShapeFactory
{
    public static Shape GetShape(string name)
    {
        var type = typeof(Shape).Assembly.GetTypes()
            .FirstOrDefault(t => t.Name == name && typeof(Shape).IsAssignableFrom(t));
    
        return type != null ? (Shape)Activator.CreateInstance(type) : new Square();
    }
}