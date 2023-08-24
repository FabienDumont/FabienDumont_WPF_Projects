using System.Collections;
using System.ComponentModel;

namespace MVVMEssentials.ViewModels;

public class ErrorsVm : BaseVm, INotifyDataErrorInfo {
    private readonly Dictionary<string, List<string>> _propertyErrors = new();

    public bool HasErrors => _propertyErrors.Any();

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName) =>
        _propertyErrors!.GetValueOrDefault(propertyName, new List<string>());

    public void AddError(string propertyName, string errorMessage) {
        if (!_propertyErrors.ContainsKey(propertyName))
            _propertyErrors.Add(propertyName, new List<string>());
        _propertyErrors[propertyName].Add(errorMessage);
        OnErrorsChanged(propertyName);
    }

    public void ClearErrors(string propertyName) {
        if (!_propertyErrors.Remove(propertyName))
            return;
        OnErrorsChanged(propertyName);
    }

    private void OnErrorsChanged(string propertyName) {
        EventHandler<DataErrorsChangedEventArgs>? errorsChanged = ErrorsChanged;
        errorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}