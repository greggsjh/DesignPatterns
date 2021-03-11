using System.Text;

namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class LambdaRemoteControl
    {
        public delegate string Command();

        public Command[] OnCommands { get; set; }
        public Command[] OffCommands { get; set; }

        public LambdaRemoteControl()
        {
            OnCommands = new Command[7];
            OffCommands = new Command[7];

            for (int i = 0; i < 7; i++)
            {
                OnCommands[i] = () => { return string.Empty; };
                OffCommands[i] = () => { return string.Empty; };
            }
        }
        public string OnButtonWasPushed(int slot)
        {
            return OnCommands[slot]();
        }

        public string OffButtonWasPushed(int slot)
        {
            return OffCommands[slot]();
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