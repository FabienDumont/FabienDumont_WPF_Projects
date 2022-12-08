using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Stores;

public class NavigationStore : INavigationStore {
    private BaseVm? _currentViewModel;

    public BaseVm? CurrentViewModel {
        get => _currentViewModel;
        set {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public event Action? CurrentViewModelChanged;

    private void OnCurrentViewModelChanged() {
        Action? viewModelChanged = CurrentViewModelChanged;
        viewModelChanged?.Invoke();
    }
}