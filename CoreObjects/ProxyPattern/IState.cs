namespace DesignPatterns.CoreObjects.ProxyPattern
{
    public interface IState
    {
        string InsertQuarter();
        string EjectQuarter();
        string TurnCrank();
        string Dispense();
        string Refill(int numberOfGumballs);
    }
}