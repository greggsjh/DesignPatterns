namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class CeilingFanMediumCommand : ICommand
    {
        public CeilingFan CeilingFan { get; set; }
        private int _prevSpeed;
        public CeilingFanMediumCommand(CeilingFan ceilingFan)
        {
            CeilingFan = ceilingFan;
        }
        public string Execute()
        {
            _prevSpeed = CeilingFan.Speed;
            CeilingFan.Medium();
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