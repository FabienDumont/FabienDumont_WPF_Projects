using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Stores;

public interface INavigationStore {
    BaseVm CurrentViewModel { set; }
}