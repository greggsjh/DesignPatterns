namespace DesignPatterns.CommandPattern
{
    internal class NoCommand : ICommand
    {
        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}