namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class Stereo
    {
        public string On()
        {
            return "Stereo is On.";
        }

        public string Off()
        {
            return "Stereo is Off.";
        }

        public string SetCd()
        {
            return "CD is On.";
        }

        public string SetDvD()
        {
            return "DVD is On.";
        }

        public string SetRadio()
        {
            return "Radio is On.";
        }

        public string SetVolume()
        {
            return "Volume is set.";
        }
    }
}