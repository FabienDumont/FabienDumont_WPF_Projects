using System.Windows;

namespace MVVMEssentials.Converters; 

public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility> {
	public BooleanToVisibilityConverter() : base(Visibility.Visible, Visibility.Collapsed) { }
}
