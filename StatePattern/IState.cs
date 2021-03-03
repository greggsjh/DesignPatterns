namespace DesignPatterns.StatePattern
{
    public interface IState
    {
        string InsertQuarter();
        string EjectQuarter();
        string TurnCrank();
        string Dispense();
    }
}