using System.Windows.Input;

namespace MVVMEssentials.Commands;

public abstract class BaseCommand : ICommand {
    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);

    protected void OnCanExecuteChanged() {
        EventHandler? canExecuteChanged = CanExecuteChanged;
        canExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}