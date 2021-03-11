using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace AllCombinations.Benchmarks
{
    [MemoryDiagnoser]
    public class AllCombinationsBenchmarks
    {
        private Combinations.AllCombinations allCombinations = new Combinations.AllCombinations();

        [Params(2, 4)]
        public int Size { get; set; }

        [ParamsSource(nameof(ValuesForNum))]
        public List<int> Num { get; set; }

        public List<List<int>> ValuesForNum => new List<List<int>> {
                                                                        Enumerable.Range(1,4).ToList(),
                                                                        Enumerable.Range(1,7).ToList(),
                                                                        Enumerable.Range(1,11).ToList(),
        };


        [Benchmark]
        public void Recursive()
        {
            allCombinations.SolveRecursive(Num, Size);
        }

        [Benchmark]
        public void Generator()
        {
            allCombinations.SolveWithGenerator(Num, Size);
        }
    }
}
