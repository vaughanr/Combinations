using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Combinations.Tests
{
    public class AllCombinationsTests
    {

        private readonly ITestOutputHelper output;


        public AllCombinationsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void SolveRecursive(List<int> nums, int size, List<List<int>> expected)
        {
            var result = new AllCombinations().SolveRecursive(nums, size);

            foreach(var r in result)
            {
                output.WriteLine("new List<int> {"+ string.Join(",", r) +"},");
            }

            Assert.Equal(expected.OrderBy(e=>string.Concat(e)), result.OrderBy(e => string.Concat(e)));
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void SolveWithGenerator(List<int> nums, int size, List<List<int>> expected)
        {
            var result = new AllCombinations().SolveWithGenerator(nums, size);

            foreach (var r in result)
            {
                output.WriteLine("new List<int> {" + string.Join(",", r) + "},");
            }

            Assert.Equal(expected.OrderBy(e => string.Concat(e)), result.OrderBy(e => string.Concat(e)));
        }

        [Fact]
        public void TestNumGen()
        {
            var result = new AllCombinations().GenerateIndexes(9, 3).ToList();

            foreach (var r in result)
            {
                output.WriteLine( string.Join(",", r));
            }

            Assert.Equal(120,result.Count);
        }

        public static IEnumerable<object[]> Data =>
       new List<object[]>
       {



            //   new object[]
            //{
            //    Enumerable.Range(1,32).ToList(),
            //    4,
            //    new List<List<int>> {
            //                  new List<int> {3,4,5},
            //                  new List<int> {2,4,5},
            //                  new List<int> {2,3,5},
            //                  new List<int> {2,3,4},
            //                  new List<int> {1,4,5},
            //                  new List<int> {1,3,5},
            //                  new List<int> {1,3,4},
            //                  new List<int> {1,2,5},
            //                  new List<int> {1,2,4},
            //                  new List<int> {1,2,3},
            //                }
            //},
       };
    }
}
