namespace DesignPatterns.CommandPattern
{
    internal class GarageDoor
    {
        internal string Up()
        {
            return "Garage Door is Open.";
        }

        internal string Down()
        {
            return "Garage Door is Closed.";
        }

        internal string Stop()
        {
            return "Garage Door is Stopped.";
        }

        internal string LightOn()
        {
            return "Garage Door Light is On.";
        }

        internal string LightOff()
        {
            return "Garage Door Light is Off.";
        }
    }
}