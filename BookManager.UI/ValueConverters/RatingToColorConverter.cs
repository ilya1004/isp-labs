using System.Globalization;

namespace BookManager.UI.ValueConverters;

public class RatingToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if ((double)value < 4.6)
        {
            return Colors.Black;
        }
        return Colors.Red;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
