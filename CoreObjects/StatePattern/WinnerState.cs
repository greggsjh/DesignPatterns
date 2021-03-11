using System.Text;

namespace DesignPatterns.CoreObjects.StatePattern
{
    public class WinnerState : IState
    {
        private GumballMachine gumballMachine;

        public WinnerState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public string Dispense()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(gumballMachine.ReleaseBall());

            if (gumballMachine.Count == 0)
            {
                gumballMachine.CurrentState = gumballMachine.SoldOutState;
            }
            else
            {
                sb.AppendLine(gumballMachine.ReleaseBall());
                sb.AppendLine("YOU'RE A WINNER! You got two gumballs for your quarter");

                if (gumballMachine.Count > 0)
                {
                    gumballMachine.CurrentState = gumballMachine.NoQuarterState;
                }
                else
                {
                    sb.AppendLine("Oops, out of gumballs!");
                    gumballMachine.CurrentState = gumballMachine.SoldOutState;
                }
            }

            return sb.ToString();
        }

        public string EjectQuarter()
        {
            return "Sorry, you already turned the crank";
        }

        public string InsertQuarter()
        {
            return "Please wait, we're already giving you a gumball";
        }

        public string TurnCrank()
        {
            return "Turning twice doesn't get you another gumball!";
        }
        public string Refill(int numberOfGumballs)
        {
            return "Sorry. Can't refill.";
        }
    }
}