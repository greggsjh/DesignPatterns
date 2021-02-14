using System;
using System.Text;
using DesignPatterns.CommandPattern;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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

                RemoteControl remoteControl = new RemoteControl();
                Light livingRoomLight = new Light("Living Room");
                Light kitchenLight = new Light("Kitchen");
                CeilingFan ceilingFan = new CeilingFan("Living Room");
                GarageDoor garage = new GarageDoor();
                Stereo stereo = new Stereo();

                LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
                LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);
                LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
                LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);

                CeilingFanOnCommand ceilingFanOnCommand = new CeilingFanOnCommand(ceilingFan);
                CeilingFanOffCommand ceilingFanOffCommand = new CeilingFanOffCommand(ceilingFan);

                GarageDoorOpenCommand garageDoorOpen = new GarageDoorOpenCommand(garage);
                GarageDoorCloseCommand garageDoorClose = new GarageDoorCloseCommand(garage);

                StereoOnWithCDCommand stereoOnWithCDCommand = new StereoOnWithCDCommand(stereo);
                StereoOffCommand stereoOffCommand = new StereoOffCommand(stereo);

                remoteControl.OnCommands[0] = livingRoomLightOn;
                remoteControl.OnCommands[1] = kitchenLightOn;
                remoteControl.OnCommands[2] = ceilingFanOnCommand;
                remoteControl.OnCommands[3] = stereoOnWithCDCommand;

                remoteControl.OffCommands[0] = livingRoomLightOff;
                remoteControl.OffCommands[1] = kitchenLightOff;
                remoteControl.OffCommands[2] = ceilingFanOffCommand;
                remoteControl.OffCommands[3] = stereoOffCommand;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(remoteControl.ToString());

                sb.AppendLine(remoteControl.OnButtonWasPushed(0));
                sb.AppendLine(remoteControl.OffButtonWasPushed(0));
                sb.AppendLine(remoteControl.OnButtonWasPushed(1));
                sb.AppendLine(remoteControl.OffButtonWasPushed(1));
                sb.AppendLine(remoteControl.OnButtonWasPushed(2));
                sb.AppendLine(remoteControl.OffButtonWasPushed(2));
                sb.AppendLine(remoteControl.OnButtonWasPushed(3));
                sb.AppendLine(remoteControl.OffButtonWasPushed(3));

                Console.WriteLine(sb.ToString());

                sb.Clear();

                RemoteControlWithUndo remoteControlWithUndo = new RemoteControlWithUndo();
                remoteControlWithUndo.OnCommands[0] = livingRoomLightOn;
                remoteControlWithUndo.OffCommands[0] = livingRoomLightOff;

                sb.AppendLine(remoteControlWithUndo.OnButtonWasPushed(0));
                sb.AppendLine(remoteControlWithUndo.OffButtonWasPushed(0));
                sb.AppendLine(remoteControlWithUndo.ToString());
                sb.AppendLine(remoteControlWithUndo.UndoButtonWasPushed());
                sb.AppendLine(remoteControlWithUndo.OffButtonWasPushed(0));
                sb.AppendLine(remoteControlWithUndo.OnButtonWasPushed(0));
                sb.AppendLine(remoteControlWithUndo.ToString());
                sb.AppendLine(remoteControlWithUndo.UndoButtonWasPushed());
                Console.WriteLine(sb.ToString());
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Undo is not implemented for this command. Message {ex.Message}");
            }
        }
    }
}
