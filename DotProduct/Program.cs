using System;

namespace DotProduct
{
    class Program
    {
        public class Solution
        {
            public int solution(int[] a, int[] b)
            {
                int answer = 0;

                for (int i = 0; i < a.Length; i++)
                {
                    answer += a[i] * b[i];
                }
                return answer;
            }
        }

        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4 };
            int[] b = { -1, -2, 0, 2 };

            Solution sol = new Solution();
            int result = sol.solution(a, b);
            Console.WriteLine(result);

        }
    }
}              
               
               

              
