using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace AllCombinations.Benchmarks
{
    [MemoryDiagnoser]
    public class AllCombinationsBenchmarks
    {
        private Combinations.AllCombinations allCombinations = new Combinations.AllCombinations();

        [Params(2, 3)]
        public int Size { get; set; }

        [ParamsSource(nameof(ValuesForNum))]
        public List<int> Num { get; set; }

        public List<List<int>> ValuesForNum => new List<List<int>> {
                                                                        new List<int>{1, 2, 3, 4 },
                                                                        new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
        };


        [Benchmark]
        public void Combination()
        {
            allCombinations.Solve(Num, Size);
        }
    }
}
