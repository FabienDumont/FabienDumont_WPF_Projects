using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MVVMEssentials.Converters; 

public class ValueToVisibilityConverter : IValueConverter {
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
		if (value != null && value.Equals(parameter)) {
			return Visibility.Visible;
		}

		return Visibility.Collapsed;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
		if (value != null && value.Equals(Visibility.Visible)) {
			return parameter;
		}

		return Binding.DoNothing;
	}
}