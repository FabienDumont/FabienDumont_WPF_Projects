
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMEssentials.ViewModels;

public class BaseVm : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string? name = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    
    public virtual void Dispose() { }
}