using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Stores;

public class ModalNavigationStore : INavigationStore {
    private BaseVm? _currentViewModel;

    public BaseVm? CurrentViewModel {
        get => _currentViewModel;
        set {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public bool IsOpen => CurrentViewModel != null;

    public event Action? CurrentViewModelChanged;

    public void Close() => CurrentViewModel = null;

    private void OnCurrentViewModelChanged() {
        Action? viewModelChanged = CurrentViewModelChanged;
        viewModelChanged?.Invoke();
    }
}