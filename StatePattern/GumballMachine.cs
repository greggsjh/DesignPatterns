namespace DesignPatterns.StatePattern
{
    public class GumballMachine
    {
        public IState CurrentState { get; internal set; }
        public IState HasQuarterState { get; internal set; }
        public IState NoQuarterState { get; internal set; }
        public IState SoldOutState { get; internal set; }
        public IState SoldState { get; internal set; }

        private int _count;

        public IState WinnerState { get; internal set; }
        public GumballMachine(int numberOfGumballs)
        {
            SoldOutState = new SoldOutState(this);
            NoQuarterState = new NoQuarterState(this);
            HasQuarterState = new HasQuarterState(this);
            SoldState = new SoldState(this);

            _count = numberOfGumballs;

            if (numberOfGumballs > 0)
            {
                CurrentState = NoQuarterState;
            }
            else
            {
                CurrentState = SoldOutState;
            }
        }
    }
}