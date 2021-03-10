namespace DesignPatterns.CoreObjects.ProxyPattern
{
    public class NoQuarterState : IState
    {
        private GumballMachine _gumballMachine;

        public NoQuarterState(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }
        public string Dispense()
        {
            return "You need to pay first";
        }

        public string EjectQuarter()
        {
            return "You haven't inserted a quarter";
        }

        public string InsertQuarter()
        {
            _gumballMachine.CurrentState = _gumballMachine.HasQuarterState;
            return "You inserted a quarter";
        }

        public string Refill(int numberOfGumballs)
        {
            return "Sorry. Can't refill.";
        }

        public string TurnCrank()
        {
            return "You turned, but there's no quarter";
        }
    }
}