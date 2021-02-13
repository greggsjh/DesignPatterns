namespace DesignPatterns.CommandPattern
{
    public class CeilingFanOffCommand : ICommand
    {
        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            CeilingFan = ceilingFan;
        }
        public CeilingFan CeilingFan { get; set; }
        public string Execute()
        {
            return CeilingFan.Off();
        }
    }
}