using System.Text;

namespace DesignPatterns.CoreObjects.ProxyPattern
{
    public class GumballMachine : IRemotableGumballMachine
    {
        public IState CurrentState { get; set; }
        public IState HasQuarterState { get; internal set; }
        public IState NoQuarterState { get; internal set; }
        public IState SoldOutState { get; internal set; }
        public IState SoldState { get; internal set; }
        public IState WinnerState { get; internal set; }
        public int Count { get; set; }
        public string Location { get; set; }

        public GumballMachine(int numberOfGumballs, string location)
        {
            SoldOutState = new SoldOutState(this);
            NoQuarterState = new NoQuarterState(this);
            HasQuarterState = new HasQuarterState(this);
            SoldState = new SoldState(this);
            WinnerState = new WinnerState(this);

            Count = numberOfGumballs;
            Location = location;

            if (numberOfGumballs > 0)
            {
                CurrentState = NoQuarterState;
            }
            else
            {
                CurrentState = SoldOutState;
            }
        }

        public string InsertQuarter()
        {
            return CurrentState.InsertQuarter();
        }

        public string EjectQuarter()
        {
            return CurrentState.EjectQuarter();
        }

        public string TurnCrank()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(CurrentState.TurnCrank());
            sb.AppendLine(CurrentState.Dispense());

            return sb.ToString();
        }

        public string ReleaseBall()
        {
            if (Count != 0)
            {
                Count--;
            }
            return "A gumball comes rolling out the slot...";
        }

        public string Refill(int numberOfGumballs)
        {
            return Count == 0 ? CurrentState.Refill(numberOfGumballs) : string.Empty;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Mighty Gumball, Inc.");
            sb.AppendLine("C#-enabled Standing Gumball Model #2021");
            sb.AppendLine($"Inventory {Count}");

            switch (CurrentState.GetType().Name)
            {
                case "NoQuarterState":
                    sb.AppendLine("Machine is waiting for quarter");
                    break;
                case "SoldOutState":
                    sb.AppendLine("Machine is sold out");
                    break;
            }

            return sb.ToString();
        }
    }
}