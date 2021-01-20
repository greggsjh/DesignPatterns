using System;

public class PlainQuack : IQuackBehavior
{   
    public void Quack()
    {
        Console.WriteLine("Quack!");
    }
}