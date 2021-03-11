using System.Text;

namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class MacroCommand : ICommand
    {
        public ICommand[] Commands { get; set; }
        public MacroCommand(ICommand[] commands)
        {
            Commands = commands;
        }
        public string Execute()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in Commands)
            {
                sb.AppendLine(c.Execute());
            }
            return sb.ToString();
        }

        public string Undo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in Commands)
            {
                sb.AppendLine(c.Undo());
            }
            return sb.ToString();
        }
    }
}