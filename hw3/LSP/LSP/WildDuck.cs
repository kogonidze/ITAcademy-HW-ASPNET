using System;
using LSP.Interfaces;

namespace LSP
{
    public class WildDuck: ISwim, IQuack, IFly
    {
        public void Swim()
        {
            Console.WriteLine("I can swim!");
        }

        public void Quack()
        {
            Console.WriteLine("Qua-qua-qua!");
        }

        public void Fly()
        {
            Console.WriteLine("I can fly!");
        }
    }
}
