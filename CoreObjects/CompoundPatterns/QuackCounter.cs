namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class QuackCounter : IQuackable
    {
        IQuackable _bird;
        public static int NumberOfQuacks { get; internal set; }

        public QuackCounter(IQuackable bird)
        {
            _bird = bird;
        }

        public string Quack()
        {
            string quack = _bird.Quack();
            NumberOfQuacks++;
            return quack;
        }

    }
}