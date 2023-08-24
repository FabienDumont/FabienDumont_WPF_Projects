using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Services;

public class ModalNavigationService<TVm> : INavigationService
    where TVm : BaseVm {
    private readonly ModalNavigationStore _navigationStore;
    private readonly Func<TVm> _createViewModel;

    public ModalNavigationService(ModalNavigationStore navigationStore, Func<TVm> createViewModel) {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate() {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}