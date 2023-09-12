using System;
using System.Diagnostics;

namespace JBQCompleteIt.Converters
{
    public class SegmentCountToFontSize : IMultiValueConverter
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

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(values.Length != 2)
            {
                throw new ArgumentException($"Two values expected for {nameof(SegmentCountToFontSize)} converter");
            }

            var origSize = 24m;

            if (values[0] == null)
            {
                // PEV - 9/12/2023 - During initialization we expect a few runs of the converter with null values
                return origSize;
            }

            var count = (int)values[0];
            var text = (string)values[1];

            // Adjust font size for small screens
            if (_isSmallScreen)
            {
                if (count > 15)
                {
                    origSize = 16m;
                }
                else if (count > 10)
                {
                    origSize = 20m;
                }

                if (text != null)
                {
                    var len = text.Length;

                    if (len > 40)
                    {
                        origSize = Math.Min(16m, origSize);
                    }
                    else if (len > 20)
                    {
                        origSize = Math.Min(20m, origSize);
                    }
                }
            }

            return AdjustFontSize(origSize);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
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
