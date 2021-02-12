namespace DesignPatterns.CommandPattern
{
    internal class SimpleRemoteControl
    {
        internal ICommand Slot { get; set; }

        internal SimpleRemoteControl()
        {

        }

        internal string ButtonWasPressed()
        {
            return Slot.Execute();
        }
    }
}