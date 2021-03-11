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
                Data = nums.OrderBy(n=>n).ToList();
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

        public List<List<int>> SolveRecursive(List<int> nums, int size)
        {
            if (size > nums.Count)
            {
                return new List<List<int>> { nums };
            }
            var all = new List<List<int>>();
            RecursiveInner(nums, size, new HashSet<Combination>(), all);
            return all;
        }
        private void RecursiveInner(IEnumerable<int> nums, int size, HashSet<Combination> unique, List<List<int>> allCombinations)
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

                    RecursiveInner(numsLessI, size, unique, allCombinations);
                }
            }
        }

        public List<List<int>> SolveWithGenerator(List<int> nums, int size)
        {
            if (size > nums.Count)
            {
                return new List<List<int>> { nums };
            }
            var all = new List<List<int>>();

            foreach(var indexCombination in GenerateIndexes(nums.Count - 1, size))
            {
                all.Add(indexCombination.Select(i => nums[i]).ToList());
            }

            return all;
        }

        public IEnumerable<List<int>> GenerateIndexes(int maxNum, int combSize)
        {
            var unique = new HashSet<Combination>();

            var indexes = new int[combSize];

            var mainIndex = combSize - 1;

            int incIndex = mainIndex;

            while (indexes.Any(i=>i< maxNum))
            {
                if(indexes[incIndex] < maxNum)
                {
                    int i = combSize - 1;

                    while (indexes[i] == maxNum && i >= 0)
                    {
                        indexes[i] = 0;
                        incIndex = i;
                        i--;
                    }

                    indexes[i]++;

                    if(indexes.Distinct().Count() == combSize)
                    {
                        unique.Add(new Combination(indexes));
                    }
                }
                else
                {
                    while(indexes[incIndex] >= maxNum && incIndex >=0)
                    {
                        incIndex--;
                    }

                    indexes[incIndex]++;

                    int i = combSize - 1;

                    while (i> incIndex)
                    {
                        indexes[i] = 0;
                        i--;
                    }

                    if (indexes.Distinct().Count() == combSize)
                    {
                        unique.Add(new Combination(indexes));
                    }

                    incIndex = combSize - 1;

                    if (incIndex < mainIndex)
                    {
                        mainIndex = incIndex;
                    }
                }
            }

            return unique.Select(c => c.Data).ToList();
        }
    }
}
