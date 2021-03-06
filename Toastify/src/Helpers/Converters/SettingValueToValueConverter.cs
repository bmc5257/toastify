﻿using System;
using System.Globalization;
using System.Windows.Data;
using Toastify.Model;

namespace Toastify.Helpers.Converters
{
    public class SettingValueToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return ((ISettingValue)value)?.GetValue();
            }
            catch
            {
                dynamic dynamicValue = value;
                return dynamicValue?.Value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type genericType = typeof(SettingValue<>).MakeGenericType(targetType.GenericTypeArguments[0]);
            var converted = (ISettingValue)Activator.CreateInstance(genericType);
            converted.SetValue(value);
            return converted;
        }
    }
}