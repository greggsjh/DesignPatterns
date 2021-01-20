using System;

public class MuteQuack : IQuackBehavior
{   
    public void Quack()
    {
        Console.WriteLine("<<Silence>>");
    }
}