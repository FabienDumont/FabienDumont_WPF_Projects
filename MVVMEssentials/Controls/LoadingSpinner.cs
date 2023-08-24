using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVMEssentials.Controls;

public class LoadingSpinner : Control {
	public static readonly DependencyProperty IsLoadingProperty =
		DependencyProperty.Register("IsLoading", typeof(bool), typeof(LoadingSpinner),
			new PropertyMetadata(false));

	public bool IsLoading {
		get { return (bool)GetValue(IsLoadingProperty); }
		set { SetValue(IsLoadingProperty, value); }
	}

	public static readonly DependencyProperty DiameterProperty =
		DependencyProperty.Register("Diameter", typeof(double), typeof(LoadingSpinner),
			new PropertyMetadata(100.0));

	public double Diameter {
		get { return (double)GetValue(DiameterProperty); }
		set { SetValue(DiameterProperty, value); }
	}

	public static readonly DependencyProperty ThicknessProperty =
		DependencyProperty.Register("Thickness", typeof(double), typeof(LoadingSpinner),
			new PropertyMetadata(1.0));

	public double Thickness {
		get { return (double)GetValue(ThicknessProperty); }
		set { SetValue(ThicknessProperty, value); }
	}

	public static readonly DependencyProperty ColorProperty =
		DependencyProperty.Register("Color", typeof(Brush), typeof(LoadingSpinner),
			new PropertyMetadata(Brushes.Black));

	public Brush Color {
		get { return (Brush)GetValue(ColorProperty); }
		set { SetValue(ColorProperty, value); }
	}

	public static readonly DependencyProperty CapProperty =
		DependencyProperty.Register("Cap", typeof(PenLineCap), typeof(LoadingSpinner),
			new PropertyMetadata(PenLineCap.Flat));

	public PenLineCap Cap {
		get { return (PenLineCap)GetValue(CapProperty); }
		set { SetValue(CapProperty, value); }
	}

	static LoadingSpinner() {
		DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingSpinner),
			new FrameworkPropertyMetadata(typeof(LoadingSpinner)));
	}
}

public class DiameterAndThicknessToStrokeDashArrayConverter : IMultiValueConverter {
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
		if (values.Length < 2 ||
		    !double.TryParse(values[0].ToString(), out double diameter) ||
		    !double.TryParse(values[1].ToString(), out double thickness)) {
			return new DoubleCollection(new[] { 0.0 });
		}

		double circumference = Math.PI * diameter;

		double lineLength = circumference * 0.75;
		double gapLength = circumference - lineLength;

		return new DoubleCollection(new[] { lineLength / thickness, gapLength / thickness });
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
		throw new NotImplementedException();
	}
}