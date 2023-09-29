using System.Globalization;

namespace TarefaPro.MAUI.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string colorString)
            {
                if (Color.TryParse(colorString, out Color color))
                    return color;
            }

            return Color.FromArgb("#919191");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
