namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class CeilingFanOnCommand : ICommand
    {
        public CeilingFanOnCommand(CeilingFan ceilingFan)
        {
            CeilingFan = ceilingFan;
        }
        public CeilingFan CeilingFan { get; set; }
        public string Execute()
        {
            return CeilingFan.On();
        }

        public string Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}