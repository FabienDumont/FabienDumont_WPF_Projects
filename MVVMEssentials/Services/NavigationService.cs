using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Services;

public class NavigationService<TVm> : INavigationService where TVm : BaseVm {
    private readonly INavigationStore _navigationStore;
    private readonly CreateViewModel<TVm> _createViewModel;

    public NavigationService(
        INavigationStore navigationStore,
        CreateViewModel<TVm> createViewModel) {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate() => _navigationStore.CurrentViewModel = _createViewModel();
}