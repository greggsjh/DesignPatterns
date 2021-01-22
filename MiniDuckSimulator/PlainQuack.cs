using System;

namespace MiniDuckSimulator
{
    public class PlainQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack!");
        }
    }
}