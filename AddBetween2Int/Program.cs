using System;


namespace AddBetween2Int
{
    public class Solution
    {
        public long solution(int a, int b)
        {
            long answer = 0;

            while (a != b)
            {
                answer += a;
                a = (a > b) ? a - 1 : a + 1;
            }
          
            return answer + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 5;
            Solution sol = new Solution();
            long result = sol.solution(a, b);
            Console.WriteLine(result);
        }
    }
}
