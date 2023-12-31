﻿using System;
using System.Diagnostics;

namespace JBQCompleteIt.Converters
{
    public class SmallScreenFontSizeScaler : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(parameter == null)
            {
                Debug.WriteLine($"'{nameof(parameter)}' is null going into {nameof(SmallScreenFontSizeScaler)}");
            }

            var parameterStr = parameter as string ?? string.Empty;
            if(!decimal.TryParse(parameterStr, out decimal origSize))
            {
                Debug.WriteLine($"'Original size defaulted for {nameof(SmallScreenFontSizeScaler)}");
                origSize = 10m;
            }

            var text = (string)value;
            var textLen = text == null ? 0 : text.Length;

            // Adjust font size based on length of text
            if (textLen > 75)
            {
                origSize = origSize * .8m;
            }
            else if (textLen > 50)
            {
                origSize = origSize * .9m;
            }

            return AdjustFontSize(origSize);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private decimal AdjustFontSize(decimal value)
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
            {
                // On MacOS on Catalyst the fonts are artificially 30% smaller, correct for this...
                return value / 0.7m;
            }

            return value;
        }
    }
}
