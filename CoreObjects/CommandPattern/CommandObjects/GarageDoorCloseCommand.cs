namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class GarageDoorCloseCommand : ICommand
    {
        public GarageDoorCloseCommand(GarageDoor garageDoor)
        {
            GarageDoor = garageDoor;
        }
        public GarageDoor GarageDoor { get; set; }
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