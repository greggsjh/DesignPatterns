namespace DesignPatterns.CommandPattern
{
    public interface ICommand
    {
        string Execute();
        string Undo();
    }
}