using BenchmarkDotNet.Running;
using System;

namespace AllCombinations.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            foreach(var s in summary)
            {
                Console.WriteLine(s);
            }
        }
    }
}
