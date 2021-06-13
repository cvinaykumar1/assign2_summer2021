using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Assignment_2_Summer_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ma);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }
    
        //q1
        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                var common_nums = nums1.Intersect(nums2);
                foreach (int item in common_nums)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //q2
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int i = 0;
                int j = nums.Length - 1;


                while (i <= j)
                {
                    // declare a median position m
                    int m = (i + j) / 2;
                    
                    if (target > nums[m])
                    {
                        i = m + 1;
                    }
                    else if (target < nums[m])
                    {
                        j = m - 1;
                    }
                    else
                    {
                        return m;
                    }
                }
                return i;
                //return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //q3
        private static int LuckyNumber(int[] nums)
        {
            try
            {
                //sort
                Array.Sort(nums);
                int count = 1;
                List<int> lucky_list = new List<int>();
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] == nums[i + 1])
                    {
                        count++;
                    }
                    if (count == nums[i] && nums[i] != nums[i + 1])
                    {
                        lucky_list.Add(nums[i]);
                        count = 1;
                    }
                }
                // sort the lucky_list
                lucky_list.Sort();
                if (lucky_list.Count == 0)
                {
                    return -1;
                }
                return lucky_list[lucky_list.Count - 1];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //q4
        private static int GenerateNums(int n)
        {
            try
            {
                int[] genNums = new int[n + 1];
                //start with 0 and 1
                genNums[0] = 0;
                genNums[1] = 1;
                for (int i = 2; i < n + 1; i++)
                {
                    int k = i / 2;
                    if (i % 2 == 0)
                    {
                        genNums[i] = genNums[k];
                    }
                    else
                    {
                        genNums[i] = genNums[k] + genNums[k + 1];
                    }
                }
                Array.Sort(genNums);
                return genNums[genNums.Length - 1];
            }
            catch (Exception)
            {

                throw;
            }

        }

        //q5
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                // iterate on each path item
                foreach (List<string> path in paths)
                {
                    for (int i = 0; i < paths.Count; i++)
                    {
                        Console.WriteLine(i);

                        if (path[1] == paths[i][1])
                        {
                            continue;
                        }
                        else
                        {
                            return paths[i][1];
                        }

                    }

                }
                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6:
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 1; j < nums.Length; j++)
                    {
                        int required_sum = nums[i] + nums[j];
                        if (required_sum == target && i != j)
                        {
                            Console.WriteLine("[" + (i + 1) + "," + (j + 1) + "]");
                            return;
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        private static void HighFive(int[,] items)
        {
            try
            {
                // new dict
                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
                var scores = new List<int>();
                for (int i = 0; i < items.Length / 2; i++)
                {
                    // if map doesn't contain key add the scores to the map
                    if (!map.ContainsKey(items[i, 0]))
                    {
                        scores = new List<int>();
                        map.Add(items[i, 0], scores);
                    }
                    else
                    {
                        scores = map[items[i, 0]];
                    }
                    scores.Add(items[i, 1]);
                    map[items[i, 0]] = scores;
                }
                foreach (var pair in map)
                {
                    int key = pair.Key;
                    List<int> value = pair.Value;
                    value.Sort();
                    value.Reverse();
                    int sum = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        sum += value[i];
                    }

                    Console.WriteLine("[" + key + "," + sum / 5 + "]");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                int[] arr_2 = new int[arr.Length];
                arr.CopyTo(arr_2, 0);
                int j = 0;
                while (j < n)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        int last = arr_2[arr.Length - 1];
                        if (i == 0)
                        {
                            arr[i] = last;
                        }
                        else
                        {
                            arr[i] = arr_2[i - 1];
                        }
                        if (j == n - 1)
                        {
                            Console.Write(arr[i]);
                        }
                    }
                    arr.CopyTo(arr_2, 0);
                    j++;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        private static int MaximumSum(int[] arr)
        {
            try
            {
                int max = arr[0];
                // start with first element as max
                int current_max = arr[0];

                for (int i = 1; i < arr.Length; i++)
                {

                    current_max = Math.Max(arr[i], current_max + arr[i]);
                    max = Math.Max(max, current_max);

                }

                return max;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                int i = 0;
                int sum = 0;
                while (i < costs.Length - 1)
                {
                    if (i + 2 == costs.Length - 1)
                    {
                        if (costs[i] + costs[i + 2] > costs[i + 1])
                        {
                            sum += costs[i + 1];
                            return sum;
                        }
                    }
                    if (costs[i] >= costs[i + 1])
                    {
                        sum += costs[i + 1];
                        i += 2;
                    }
                    else
                    {
                        sum = sum + costs[i];
                        i += 1;
                    }
                }
                return sum;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
