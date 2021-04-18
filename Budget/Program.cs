using System;

namespace Budget
{
    public class Solution
    {
        public int solution(int[] d, int budget)
        {
            int answer = 0;
            // 제일 작은수부터 예산 지정해주는 방법
            Array.Sort(d);

            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] <= budget)
                {
                    budget -= d[i];
                    answer++;
                }
            }
            return answer;
        }
    }

            
    class Program
    {
        static void Main(string[] args)
        {
            int[] d = { 2, 2, 3, 3 };
            int budget = 10;

            Solution sol = new Solution();
            int result = sol.solution(d, budget);
            Console.WriteLine(result);
            
        }
    }
}
