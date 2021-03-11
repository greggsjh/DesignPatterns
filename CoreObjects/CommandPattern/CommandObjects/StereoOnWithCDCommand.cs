using System.Text;

namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class StereoOnWithCDCommand : ICommand
    {
        public StereoOnWithCDCommand(Stereo stereo)
        {
            Stereo = stereo;
        }
        public Stereo Stereo { get; set; }
        public string Execute()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Stereo.On());
            sb.AppendLine(Stereo.SetCd());
            sb.Append(Stereo.SetVolume());

            return sb.ToString();
        }

        public string Undo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Stereo.Off());

            return sb.ToString();
        }
    }
}