using System;

namespace WithoutLSP
{
    public class RubberDuck: Duck
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
            throw new NotImplementedException("RubberDuck can not fly!");
        }
    }
}
