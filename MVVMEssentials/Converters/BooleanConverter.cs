using System.Globalization;
using System.Windows.Data;

namespace MVVMEssentials.Converters; 

public class BooleanConverter<T> : IValueConverter {
	public BooleanConverter(T trueValue, T falseValue) {
		True = trueValue;
		False = falseValue;
	}

	public T True { get; set; }
	public T False { get; set; }

	public virtual object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
		return value is true ? True : False;
	}

	public virtual object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
		return value is T value1 && EqualityComparer<T>.Default.Equals(value1, True);
	}
}