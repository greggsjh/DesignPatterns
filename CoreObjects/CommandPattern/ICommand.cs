namespace DesignPatterns.CoreObjects.CommandPattern
{
    public interface ICommand
    {
        string Execute();
        string Undo();
    }
}