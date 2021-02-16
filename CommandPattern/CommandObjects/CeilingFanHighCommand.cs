namespace DesignPatterns.CommandPattern
{
    public class CeilingFanHighCommand : ICommand
    {
        public CeilingFan CeilingFan { get; set; }
        private int _prevSpeed;
        public CeilingFanHighCommand(CeilingFan ceilingFan)
        {
            CeilingFan = ceilingFan;
        }

        public string Execute()
        {
            _prevSpeed = CeilingFan.Speed;
            CeilingFan.High();
            return CeilingFan.On();
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