namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class GooseAdapter : IQuackable
    {
        IHonkable _goose;
        public GooseAdapter(IHonkable goose)
        {
            _goose = goose;
        }

        public string Quack()
        {
            return _goose.Honk();
        }
    }
}