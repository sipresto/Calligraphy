using System.Globalization;
using System.Windows.Data;

namespace Calligraphy.Presentation.Converters;

public class StarFillConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int currentStars && parameter != null)
        {
            if (int.TryParse(parameter.ToString(), out int requiredStars))
            {
                return currentStars >= requiredStars;
            }
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}