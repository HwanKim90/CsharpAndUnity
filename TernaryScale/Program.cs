using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ternary
{
    public class Solution
    {
        public int solution(int n)
        {
            int answer = 0;
            int division;
            int lastValue;

            // 3진법으로 바꾸기
            Stack<int> stack = new Stack<int>();

            while (true)
            {
                division = n / 3;
                lastValue = n % 3;
                stack.Push(lastValue);
                n = division;
                if (division == 0) break;
            }

            int stackLength = stack.Count;

            for (int i = 0; i < stackLength; i++)
            {
                //Pop() => 맨앞 개체 제거 후 반환
                //Pow(double x, double y) = x의 y승
                answer += (int)(stack.Pop() * Math.Pow(3, i));
            }

            return answer;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int result1 = sol.solution(45);
            int result2 = sol.solution(125);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}
