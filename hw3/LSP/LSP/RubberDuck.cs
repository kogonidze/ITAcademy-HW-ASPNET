using System;
using LSP.Interfaces;

namespace LSP
{
    public class RubberDuck: ISwim, IQuack
    {
        public void Swim()
        {
            Console.WriteLine("I can swim!");
        }

        public void Quack()
        {
            Console.WriteLine("Qua-qua-qua!");
        }
    }
}
