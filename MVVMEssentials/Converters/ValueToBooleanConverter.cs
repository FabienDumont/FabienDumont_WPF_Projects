using System;
using System.Globalization;
using System.Windows.Data;

namespace MVVMEssentials.Converters;

public class ValueToBooleanConverter : IValueConverter {
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        return value is not null && value.Equals(parameter);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        return value is not null && (bool)value && parameter is not null ? parameter : Binding.DoNothing;
    }
}