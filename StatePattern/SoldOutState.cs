namespace DesignPatterns.StatePattern
{
    public class SoldOutState : IState
    {
        private GumballMachine gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public string Dispense()
        {
            return "No gumball dispensed";
        }

        public string EjectQuarter()
        {
            return "You can't eject, you haven't insertad a quarter yet";
        }

        public string InsertQuarter()
        {
            return "You can't insert a quarter, the machine is sold out";
        }

        public string Refill(int numberOfGumballs)
        {
            gumballMachine.Count = numberOfGumballs;
            gumballMachine.CurrentState = gumballMachine.NoQuarterState;
            return "Machine has been refilled";
        }

        public string TurnCrank()
        {
            return "You turned, but there are no gumballs";
        }
    }
}