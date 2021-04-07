using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoPickAndAddSELF
{
    class Solution
    {
        public int[] solution(int[] numbers)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int sum = numbers[i] + numbers[j];
                    if (!list.Contains(sum))
                    {
                        list.Add(sum);
                    }
                }
            }
            list.Sort();
            int[] answer = list.ToArray();
            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 2, 3, 4, 5 };
            Solution sol = new Solution();
            int[] result = sol.solution(num);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
