namespace Calligraphy.Presentation.Commands;

public class ResetCommand : CommandBase
{
    private readonly Action _execute;
    
    public ResetCommand(Action execute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }
    
    public override void Execute(object parameter)
    {
        _execute.Invoke();
    }
}