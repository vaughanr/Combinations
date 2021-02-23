using System;
using System.Collections.Generic;
using Xunit;

namespace Combinations.Tests
{
    public class AllCombinationsTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Test1(List<int> nums, int size, List<List<int>> expected)
        {
            var result = new AllCombinations().Solve(nums, size);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Data =>
       new List<object[]>
       {
            //new object[] 
            //{ 
            //    new List<int> { 1,2,3}, 
            //    2,
            //    new List<List<int>> {
            //                    new List<int> {2,3} ,
            //                    new List<int> {1,3} ,
            //                    new List<int> {1,2} ,
            //                }
            //},

               new object[]
            {
                new List<int> { 1,2,3,4, 5},
                3,
                new List<List<int>> {
                                new List<int> {2,3} ,
                                new List<int> {1,3} ,
                                new List<int> {1,2} ,
                            }
            },
       };
    }
}
