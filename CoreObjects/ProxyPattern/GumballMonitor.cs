using System.Text;

namespace DesignPatterns.CoreObjects.ProxyPattern
{
    public class GumballMonitor
    {
        private IRemotableGumballMachine _machine;

        public GumballMonitor(IRemotableGumballMachine machine)
        {
            _machine = machine;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Gumball Machine: {_machine.Location}");
            sb.AppendLine($"Current inventory: {_machine.Count}");
            sb.AppendLine($"Current state: {_machine.CurrentState.GetType().Name}");

            return sb.ToString();
        }
    }
}