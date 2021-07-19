using System;

namespace WithoutLSP
{
    public class WildDuck: Duck
    {
        public override void Quack()
        {
            Console.WriteLine("Qua-qua-qua!");
        }

        public override void Swim()
        {
            Console.WriteLine("I can swim!");
        }

        public override void Fly()
        {
            Console.WriteLine("I can fly!");
        }
    }
}
