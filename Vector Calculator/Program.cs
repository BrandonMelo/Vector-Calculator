using System;

namespace Vector_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector test1 = new Vector(1, 2, 3);
            Vector test2 = new Vector(-1, 2, -3);

            // This should be 2.0137073708685356
            Console.WriteLine(Vector.ProjectOnto(test1, test2));
        }
    }
}
