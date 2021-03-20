namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class AbstractGooseFactory : IAbstractGooseFactory
    {
        public IHonkable CreateGoose()
        {
            return new Goose();
        }
    }
}