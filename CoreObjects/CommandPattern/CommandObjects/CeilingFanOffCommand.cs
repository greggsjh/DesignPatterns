namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class CeilingFanOffCommand : ICommand
    {
        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            CeilingFan = ceilingFan;
        }
        private int _prevSpeed;
        public CeilingFan CeilingFan { get; set; }
        public string Execute()
        {
            _prevSpeed = CeilingFan.Speed;
            CeilingFan.Speed = CeilingFan.OFF;
            return CeilingFan.Off();
        }

        public string Undo()
        {
            switch (_prevSpeed)
            {
                case CeilingFan.HIGH:
                    CeilingFan.High();
                    break;
                case CeilingFan.LOW:
                    CeilingFan.Low();
                    break;
                case CeilingFan.MEDIUM:
                    CeilingFan.Medium();
                    break;
                case CeilingFan.OFF:
                    return CeilingFan.Off();
            }

            return CeilingFan.On();
        }
    }
}