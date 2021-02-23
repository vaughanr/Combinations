using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Combinations
{
    public class AllCombinations
    {
        private class Combination
        {
            public List<int> Data { get; private set; }
            public Combination(IEnumerable<int> nums)
            {
                Data = nums.OrderBy(n => n).ToList();
            }

            public override int GetHashCode()
            {
                int hashcode = 0;
                unchecked
                {
                    foreach (int num in Data)
                    {
                        hashcode += num.GetHashCode();
                    }
                    return hashcode;
                }
            }
            public override bool Equals(object obj)
            {
                Combination other = obj as Combination;
                return other != null && Data.SequenceEqual(other.Data);
            }
        }


        public List<List<int>> Solve(List<int> nums, int size)
        {
            if (size > nums.Count)
            {
                return new List<List<int>> { nums };
            }
            var all = new List<List<int>>();
            Inner(nums, size, new HashSet<Combination>(), all);
            return all;
        }

        private void Inner(IEnumerable<int> nums, int size, HashSet<Combination> unique, List<List<int>> allCombinations)
        {
            if (nums.Count() == size)
            {
                var combination = new Combination(nums);

                if (unique.Add(combination))
                {
                    allCombinations.Add(combination.Data);
                }
            }

            if (nums.Count() > size)
            {
                for (int i = 0; i < nums.Count(); i++)
                {
                    var numsLessI = Enumerable.Concat(nums.Take(i), nums.Skip(i + 1).Take(nums.Count())).ToArray();

                    Inner(numsLessI, size, unique, allCombinations);
                }
            }
        }
    }
}
