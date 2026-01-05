using System.Globalization;
using System.Windows.Data;
using DivineTool64.Models;

namespace DivineTool64.Converters
{
    public class YaoToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Yao yao)
            {
                return yao.Value == 1 ? "━━━━━━" : "━━  ━━";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}