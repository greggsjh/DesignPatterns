namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class AbstractDuckFactory : IAbstractDuckFactory
    {
        public IQuackable CreateDuckCall()
        {
            return new DuckCall();
        }

        public IQuackable CreateGooseAdapter()
        {
            return new GooseAdapter(new AbstractGooseFactory().CreateGoose());
        }

        public IQuackable CreateRedheadDuck()
        {
            return new RedheadDuck();
        }

        public IQuackable CreateRubberDuck()
        {
            return new RubberDucky();
        }

        public IQuackable CreateWildMallard()
        {
            return new WildMallard();
        }
    }
}