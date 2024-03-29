using System.Text;

namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class RemoteControlWithUndo
    {
        public ICommand[] OnCommands { get; set; }
        public ICommand[] OffCommands { get; set; }
        public ICommand UndoCommand { get; set; }

        public RemoteControlWithUndo()
        {
            OnCommands = new ICommand[7];
            OffCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                OnCommands[i] = noCommand;
                OffCommands[i] = noCommand;
            }

            UndoCommand = noCommand;
        }

        public string OnButtonWasPushed(int slot)
        {
            UndoCommand = OnCommands[slot];
            return OnCommands[slot].Execute();
        }

        public string OffButtonWasPushed(int slot)
        {
            UndoCommand = OffCommands[slot];
            return OffCommands[slot].Execute();
        }

        public string UndoButtonWasPushed()
        {
            return UndoCommand.Undo();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 7; i++)
            {
                sb.AppendLine($"[slot {i + 1}] {OnCommands[i].GetType().Name}   {OffCommands[i].GetType().Name}");
            }

            sb.AppendLine($"[undo] {UndoCommand.GetType().Name}");

            return sb.ToString();
        }
    }
}