using System;
using System.Text;

namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class RemoteControl
    {
        public ICommand[] OnCommands { get; set; }
        public ICommand[] OffCommands { get; set; }

        public RemoteControl()
        {
            OnCommands = new ICommand[7];
            OffCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                OnCommands[i] = noCommand;
                OffCommands[i] = noCommand;
            }
        }

        public string OnButtonWasPushed(int slot)
        {
            return OnCommands[slot].Execute();
        }

        public string OffButtonWasPushed(int slot)
        {
            return OffCommands[slot].Execute();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 7; i++)
            {
                sb.AppendLine($"[slot {i + 1}] {OnCommands[i].GetType().Name}   {OffCommands[i].GetType().Name}");
            }

            return sb.ToString();
        }

    }
}