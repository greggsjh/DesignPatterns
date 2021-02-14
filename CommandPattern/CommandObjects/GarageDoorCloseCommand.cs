namespace DesignPatterns.CommandPattern
{
    internal class GarageDoorCloseCommand : ICommand
    {
        internal GarageDoorCloseCommand(GarageDoor garageDoor)
        {
            GarageDoor = garageDoor;
        }
        internal GarageDoor GarageDoor { get; set; }
        public string Execute()
        {
            return GarageDoor.Down();
        }

        public string Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}