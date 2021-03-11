using System.Text;

namespace DesignPatterns.CoreObjects.FacadePattern
{
    public class HomeTheaterFacade
    {
        public Amplifier Amp { get; set; }
        public Tuner Tuner { get; set; }
        public DvdPlayer Dvd { get; set; }
        public CdPlayer Cd { get; set; }
        public Projector Projector { get; set; }
        public TheaterLights Lights { get; set; }
        public Screen Screen { get; set; }
        public PopcornPopper Popper { get; set; }

        public HomeTheaterFacade(Amplifier a, Tuner t, DvdPlayer d, CdPlayer c, Projector p, Screen s, TheaterLights l, PopcornPopper pp)
        {
            Amp = a;
            Tuner = t;
            Dvd = d;
            Cd = c;
            Projector = p;
            Screen = s;
            Lights = l;
            Popper = pp;
        }

        public string WatchMovie(string movie)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Get ready to watch a movie ...");
            sb.AppendLine(Popper.On());
            sb.AppendLine(Popper.Pop());
            sb.AppendLine(Lights.Dim(10));
            sb.AppendLine(Screen.Down());
            sb.AppendLine(Projector.On());
            sb.AppendLine(Projector.WideScreenMode());
            sb.AppendLine(Amp.On());
            sb.AppendLine(Amp.SetDvd());
            sb.AppendLine(Amp.SetSurroundSound());
            sb.AppendLine(Amp.SetVolume(5));
            sb.AppendLine(Dvd.On());
            sb.AppendLine(Dvd.Play(movie));

            return sb.ToString();
        }

        public string EndMovie()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Shutting movie theater down ...");
            sb.AppendLine(Popper.Off());
            sb.AppendLine(Lights.On());
            sb.AppendLine(Screen.Up());
            sb.AppendLine(Projector.Off());
            sb.AppendLine(Amp.Off());
            sb.AppendLine(Dvd.Stop());
            sb.AppendLine(Dvd.Eject());
            sb.AppendLine(Dvd.Off());

            return sb.ToString();
        }
    }
}