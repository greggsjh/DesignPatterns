namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class GarageDoorOpenCommand : ICommand
    {
        public GarageDoorOpenCommand(GarageDoor garageDoor)
        {
            GarageDoor = garageDoor;
        }

        public GarageDoor GarageDoor { get; private set; }

        public string Execute()
        {
            return GarageDoor.Up();
        }

        public string Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}