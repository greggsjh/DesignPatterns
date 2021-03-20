namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public interface IAbstractDuckFactory
    {
        IQuackable CreateWildMallard();
        IQuackable CreateRedheadDuck();
        IQuackable CreateDuckCall();
        IQuackable CreateRubberDuck();
        IQuackable CreateGooseAdapter();
    }
}