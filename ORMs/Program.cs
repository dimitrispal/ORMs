using System;

namespace ORMs
{
    class Program
    {
        static void Main(string[] args)
        {
            ORMs.Example1.DbContextSample.Run();
            //ORMs.Example2.DbSetSample.Run();
            //ORMs.Example4.RelationshipsSample.Run();

            Console.WriteLine("-- press any key to exit --");
            Console.ReadKey();
        }
    }
}
