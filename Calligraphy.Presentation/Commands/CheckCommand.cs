namespace Calligraphy.Presentation.Commands;

public class CheckCommand : CommandBase
{
    private readonly Action _execute;
    
    public CheckCommand(Action execute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }
    
    public override void Execute(object parameter)
    {
        _execute.Invoke();
    }
}