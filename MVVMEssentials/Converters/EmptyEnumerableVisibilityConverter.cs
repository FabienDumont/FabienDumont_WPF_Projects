using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MVVMEssentials.Converters;

public class EmptyEnumerableVisibilityConverter : IValueConverter {
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
		if (value != null) {
			
			IEnumerable enumerable = (IEnumerable)value;
			int count = 0;
			foreach (var item in enumerable) {
				count++;
			}

			if (count > 0) {
				return Visibility.Visible;
			}
		}
		
		return Visibility.Collapsed;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
		throw new NotImplementedException();
	}
}