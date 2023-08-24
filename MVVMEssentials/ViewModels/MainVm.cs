using MVVMEssentials.Stores;

namespace MVVMEssentials.ViewModels;

public class MainVm : BaseVm {
    private readonly NavigationStore _navigationStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public BaseVm? CurrentViewModel => _navigationStore.CurrentViewModel;

    public BaseVm? CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

    public bool IsOpen => _modalNavigationStore.IsOpen;

    public MainVm(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore) {
        _navigationStore = navigationStore;
        _modalNavigationStore = modalNavigationStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;
    }

    private void OnCurrentViewModelChanged() => OnPropertyChanged(nameof(CurrentViewModel));

    private void OnCurrentModalViewModelChanged() {
        OnPropertyChanged(nameof(CurrentModalViewModel));
        OnPropertyChanged(nameof(IsOpen));
    }
}