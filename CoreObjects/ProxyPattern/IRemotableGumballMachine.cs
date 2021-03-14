namespace DesignPatterns.CoreObjects.ProxyPattern
{
    public interface IRemotableGumballMachine
    {
        IState CurrentState { get; }
        string Location { get; }
        int Count { get; }
    }
}