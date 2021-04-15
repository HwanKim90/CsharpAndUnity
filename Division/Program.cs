using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class Program
    {
        public class Solution
        {
            public int[] solution(int[] arr, int divisor)
            {
                List<int> list = new List<int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % divisor == 0)
                    {
                        list.Add(arr[i]);
                    }

                }

                if (list == null || !list.Any())
                {
                    list.Add(-1);
                }

                list.Sort();
                return list.ToArray();
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 5, 9, 7, 10 };
            int divisor = 5;

            Solution sol = new Solution();
            
            int[] result = sol.solution(arr, divisor);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
                
        }
    }
}
                




