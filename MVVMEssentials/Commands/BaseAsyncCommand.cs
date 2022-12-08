namespace MVVMEssentials.Commands;

public abstract class BaseAsyncCommand : BaseCommand {
    private readonly Action<Exception>? _onException;
    private bool _isExecuting;

    public bool IsExecuting {
        get => _isExecuting;
        private set {
            _isExecuting = value;
            OnCanExecuteChanged();
        }
    }

    public BaseAsyncCommand(Action<Exception>? onException = null) => _onException = onException;

    public override bool CanExecute(object? parameter) => !IsExecuting && base.CanExecute(parameter);

    public override async void Execute(object? parameter) {
        IsExecuting = true;
        try {
            await ExecuteAsync(parameter);
        }
        catch (Exception ex) {
            Action<Exception>? onException = _onException;
            onException?.Invoke(ex);
        }

        IsExecuting = false;
    }

    protected abstract Task ExecuteAsync(object? parameter);
}