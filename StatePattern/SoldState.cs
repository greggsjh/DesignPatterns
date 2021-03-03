namespace DesignPatterns.StatePattern
{
    public class SoldState : IState
    {
        private GumballMachine gumballMachine;

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public string Dispense()
        {
            throw new System.NotImplementedException();
        }

        public string EjectQuarter()
        {
            throw new System.NotImplementedException();
        }

        public string InsertQuarter()
        {
            throw new System.NotImplementedException();
        }

        public string TurnCrank()
        {
            throw new System.NotImplementedException();
        }
    }
}