using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Services;

public class ParameterNavigationService<TParameter, TVm> where TVm : BaseVm {
    private readonly NavigationStore _navigationStore;
    private readonly CreateViewModel<TParameter, TVm> _createViewModel;

    public ParameterNavigationService(
        NavigationStore navigationStore,
        CreateViewModel<TParameter, TVm> createViewModel) {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate(TParameter parameter) =>
        _navigationStore.CurrentViewModel = _createViewModel(parameter);
}