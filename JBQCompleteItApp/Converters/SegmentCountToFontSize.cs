using System;
using System.Diagnostics;

namespace JBQCompleteIt.Converters
{
    public class SegmentCountToFontSize : IValueConverter
    {
        static bool _isSmallScreen = false;

        static SegmentCountToFontSize()
        {
            var minDim = Math.Min(DeviceDisplay.Current.MainDisplayInfo.Height, DeviceDisplay.Current.MainDisplayInfo.Width);
            var minDimDensityRatio = minDim / DeviceDisplay.Current.MainDisplayInfo.Density;

            _isSmallScreen = minDimDensityRatio < 600;

            if(_isSmallScreen)
            {
                Debug.WriteLine("SegmentCountToFontSize - Small screen detected!");
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var count = (int)value;

            var origSize = 24m;

            // Adjust font size for small screens
            if (_isSmallScreen)
            {
                if (count > 20)
                {
                    origSize = 16m;
                }
                else if (count > 10)
                {
                    origSize = 20m;
                }
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
