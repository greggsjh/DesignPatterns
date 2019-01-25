using System;

public class Mallard : Duck
{
    public Mallard()
    {
        quackBehavior = new PlainQuack();
        flyBehavior = new FlyWithWings();
    }

    public override void Display()
    {
        Console.WriteLine("I'm a real Mallard Duck!");
    }
}