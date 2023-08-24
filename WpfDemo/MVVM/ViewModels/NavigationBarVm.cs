using System.Windows.Input;
using MVVMEssentials.ViewModels;

namespace WpfDemo.MVVM.ViewModels; 

public class NavigationBarVm : BaseVm {
    public ICommand GameNavigateCommand { get; set; }

    public NavigationBarVm() {
        
    }
}