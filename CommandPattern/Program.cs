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
                Console.WriteLine(ProcessSimpleRemote());
                Console.WriteLine(ProcessRemoteControl());
                Console.WriteLine(ProcessRemoteControlWithUndo());
                Console.WriteLine(ProcessRemoteControlWithUndoComplex());
                Console.WriteLine(ProcessMacroCommand());

            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Undo is not implemented for this command. Message {ex.Message}");
            }
        }

        private static string ProcessMacroCommand()
        {
            StringBuilder sb = new StringBuilder();

            RemoteControl remoteControl = new RemoteControl();

            Light light = new Light("Living Room");
            Stereo stereo = new Stereo();

            LightOnCommand lightOn = new LightOnCommand(light);
            StereoOnWithCDCommand stereoOn = new StereoOnWithCDCommand(stereo);

            LightOffCommand lightOff = new LightOffCommand(light);
            StereoOffCommand stereoOff = new StereoOffCommand(stereo);

            ICommand[] partyOn = { lightOn, stereoOn };
            ICommand[] partyOff = { lightOff, stereoOff };

            MacroCommand partyOnMacro = new MacroCommand(partyOn);
            MacroCommand partyOffMacro = new MacroCommand(partyOff);

            remoteControl.OnCommands[0] = partyOnMacro;
            remoteControl.OffCommands[0] = partyOffMacro;

            sb.AppendLine(remoteControl.ToString());
            sb.AppendLine("--- Pushing Macro On ---");
            sb.AppendLine(remoteControl.OnButtonWasPushed(0));
            sb.AppendLine("--- Pushing Macro Off ---");
            sb.AppendLine(remoteControl.OffButtonWasPushed(0));

            return sb.ToString();
        }

        private static string ProcessRemoteControlWithUndoComplex()
        {
            StringBuilder sb = new StringBuilder();

            RemoteControlWithUndo remoteControlUndo = new RemoteControlWithUndo();
            CeilingFan ceilingFan1 = new CeilingFan("Living Room");

            remoteControlUndo.OnCommands[0] = new CeilingFanMediumCommand(ceilingFan1);
            remoteControlUndo.OffCommands[0] = new CeilingFanOffCommand(ceilingFan1);

            remoteControlUndo.OnCommands[1] = new CeilingFanHighCommand(ceilingFan1);
            remoteControlUndo.OffCommands[1] = new CeilingFanOffCommand(ceilingFan1);

            sb.AppendLine(remoteControlUndo.OnButtonWasPushed(0));
            sb.AppendLine(remoteControlUndo.OffButtonWasPushed(0));
            sb.AppendLine(remoteControlUndo.ToString());
            sb.AppendLine(remoteControlUndo.UndoButtonWasPushed());

            sb.AppendLine(remoteControlUndo.OnButtonWasPushed(1));
            sb.AppendLine(remoteControlUndo.ToString());
            sb.AppendLine(remoteControlUndo.UndoButtonWasPushed());

            return sb.ToString();
        }

        private static string ProcessRemoteControlWithUndo()
        {
            StringBuilder sb = new StringBuilder();

            RemoteControlWithUndo remoteControlWithUndo = new RemoteControlWithUndo();

            Light livingRoomLight = new Light("Living Room");

            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

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

            return sb.ToString();
        }

        private static string ProcessRemoteControl()
        {
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

            return sb.ToString();
        }

        private static string ProcessSimpleRemote()
        {
            StringBuilder sb = new StringBuilder();
            SimpleRemoteControl remote = new SimpleRemoteControl();
            Light light = new Light();
            LightOnCommand lightOn = new LightOnCommand(light);
            GarageDoor garageDoor = new GarageDoor();
            GarageDoorOpenCommand garageDoorOpenCommand = new GarageDoorOpenCommand(garageDoor);

            remote.Slot = lightOn;
            sb.AppendLine(remote.ButtonWasPressed());
            remote.Slot = garageDoorOpenCommand;
            sb.AppendLine(remote.ButtonWasPressed());

            return sb.ToString();
        }
    }
}
