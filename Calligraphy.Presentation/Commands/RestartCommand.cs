namespace Calligraphy.Presentation.Commands;

public class RestartCommand : CommandBase
{
    private readonly Action _execute;
    
    public RestartCommand(Action execute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }
    
    public override void Execute(object parameter)
    {
        _execute.Invoke();
    }
}