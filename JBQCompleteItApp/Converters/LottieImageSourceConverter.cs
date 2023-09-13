using SkiaSharp.Extended.UI.Controls;
using SkiaSharp.Extended.UI.Controls.Converters;
using System;

namespace JBQCompleteIt.Converters
{
    public class LottieImageSourceConverter : IValueConverter
    {
        private static SKLottieImageSourceConverter _lottieConverter = new SKLottieImageSourceConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var strVal = (string)value;

            if (strVal == null)
            {
                return null;
            }
            else
            {
                return (SKLottieImageSource)_lottieConverter.ConvertFromString(strVal);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
