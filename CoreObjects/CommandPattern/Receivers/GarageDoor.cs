namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class GarageDoor
    {
        public string Up()
        {
            return "Garage Door is Open.";
        }

        public string Down()
        {
            return "Garage Door is Closed.";
        }

        public string Stop()
        {
            return "Garage Door is Stopped.";
        }

        public string LightOn()
        {
            return "Garage Door Light is On.";
        }

        public string LightOff()
        {
            return "Garage Door Light is Off.";
        }
    }
}