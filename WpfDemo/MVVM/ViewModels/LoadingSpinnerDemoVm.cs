using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace WpfDemo.MVVM.ViewModels; 

public class LoadingSpinnerDemoVm : BaseVm {
	
	public ICommand ReturnCommand { get; set; }
	public LoadingSpinnerDemoVm(StringStore stringStore, INavigationService closeNavigationService) {
		ReturnCommand = new NavigateCommand(closeNavigationService);
	}
}