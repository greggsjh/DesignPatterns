namespace DesignPatterns.CoreObjects.CommandPattern
{
    public class SimpleRemoteControl
    {
        public ICommand Slot { get; set; }

        public SimpleRemoteControl()
        {

        }

        public string ButtonWasPressed()
        {
            return Slot.Execute();
        }
    }
}