using System;
using System.Text;

namespace DesignPatterns.CommandPattern
{
    internal class RemoteControl
    {
        public ICommand[] OnCommands { get; set; }
        public ICommand[] OffCommands { get; set; }

        internal RemoteControl()
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

        internal string OnButtonWasPushed(int slot)
        {
            return OnCommands[slot].Execute();
        }

        internal string OffButtonWasPushed(int slot)
        {
            return OffCommands[slot].Execute();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in OnCommands)
            {
                int index = Array.IndexOf(OnCommands, c);
                sb.AppendLine($"[slot {index}] {c.GetType().Name}    {OffCommands[index].GetType().Name}");
            }

            return sb.ToString();
        }

    }
}