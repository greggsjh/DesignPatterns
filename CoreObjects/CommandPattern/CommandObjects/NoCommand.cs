namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class NoCommand : ICommand
    {
        public string Execute()
        {
            throw new System.NotImplementedException();
        }

        public string Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}