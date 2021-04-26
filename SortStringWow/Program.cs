using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStringWow
{
    public class Solution
    {
        public string[] solution(string[] strings, int n)
        {
            string[] answer = new string[strings.Length];
            
            for (int i = 0; i < strings.Length; i++)
            {
                answer[i] = strings[i][n] + strings[i];
            }
            Array.Sort(answer);
            for (int i = 0; i <strings.Length; i++)
            {
                answer[i] = answer[i].Substring(1);
            }

            return answer;
        }

            

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "sun", "bed", "car" };
            int n = 1;

            Solution sol = new Solution();
            string[] result = sol.solution(strings, n);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
