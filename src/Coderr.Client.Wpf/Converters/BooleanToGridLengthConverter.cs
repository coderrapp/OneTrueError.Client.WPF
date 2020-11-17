﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Coderr.Client.Wpf.Converters
{
    /// <summary>
    /// Converts our flags to different grid sizes. 
    /// </summary>
    [ValueConversion(typeof(bool), typeof(GridLength))]
    public class BooleanToGridLengthConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool) value;
            var multiplier = int.Parse(parameter.ToString());
            if (boolValue)
            {
                return new GridLength(multiplier, GridUnitType.Star);
            }

            return new GridLength(0);
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gridLength = (GridLength) value;
            if (gridLength.Value == 0)
            {
                return false;
            }

            return true;
        }
    }
}
