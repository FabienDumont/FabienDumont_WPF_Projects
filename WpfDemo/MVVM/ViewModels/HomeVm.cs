using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace WpfDemo.MVVM.ViewModels; 

public class HomeVm : BaseVm {
	public ICommand LoadingSpinnerDemoCommand { get; set; }

	public HomeVm(StringStore stringStore, INavigationService loadingSpinnerDemoNavigationService) {
		LoadingSpinnerDemoCommand = new RelayCommand(
			_ => {
				loadingSpinnerDemoNavigationService.Navigate();
			}
		);
	}
	
}