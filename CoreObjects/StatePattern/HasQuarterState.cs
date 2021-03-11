using System;
using System.Text;

namespace DesignPatterns.CoreObjects.StatePattern
{
    public class HasQuarterState : IState
    {
        Random randomWinner = new Random(DateTime.Now.Millisecond);
        private GumballMachine gumballMachine;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public string Dispense()
        {
            return "No gumball dispensed";
        }

        public string EjectQuarter()
        {
            gumballMachine.CurrentState = gumballMachine.NoQuarterState;
            return "Quarter returned";
        }

        public string InsertQuarter()
        {
            return "You can't insert another quarter";
        }

        public string TurnCrank()
        {
            int winner = randomWinner.Next(10);
            if ((winner == 0) && (gumballMachine.Count > 1))
            {
                gumballMachine.CurrentState = gumballMachine.WinnerState;
            }
            else
            {
                gumballMachine.CurrentState = gumballMachine.SoldState;
            }

            return "You turned...";
        }
        public string Refill(int numberOfGumballs)
        {
            return "Sorry. Can't refill.";
        }
    }
}