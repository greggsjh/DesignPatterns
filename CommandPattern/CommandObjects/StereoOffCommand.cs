namespace DesignPatterns.CommandPattern
{
    public class StereoOffCommand : ICommand
    {
        public StereoOffCommand(Stereo stereo)
        {
            Stereo = stereo;
        }
        public Stereo Stereo { get; set; }
        public string Execute()
        {
            return Stereo.Off();
        }

        public string Undo()
        {
            return Stereo.On();
        }
    }
}