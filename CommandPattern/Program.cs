using System;
using DesignPatterns.CommandPattern;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleRemoteControl remote = new SimpleRemoteControl();
            Light light = new Light();
            LightOnCommand lightOn = new LightOnCommand(light);
            GarageDoor garageDoor = new GarageDoor();
            GarageDoorOpenCommand garageDoorOpenCommand = new GarageDoorOpenCommand(garageDoor);

            remote.Slot = lightOn;
            Console.WriteLine(remote.ButtonWasPressed());
            remote.Slot = garageDoorOpenCommand;
            Console.WriteLine(remote.ButtonWasPressed());
        }
    }
}
