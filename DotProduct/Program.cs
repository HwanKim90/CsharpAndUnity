using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotProduct
{
    class Program
    {
        public class Solution
        {
            public int solution(int[] a, int[] b)
            {
                int result = 0;
                int answer = 0;

                for (int i = 0; i < a.Length; i++)
                {
                    result = a[i] * b[i];
                    answer += result;
                }
                return answer;
            }
        }
        static void Main(string[] args)
        {
            int[] a = { -1,0,1 };
            int[] b = { 1,0,-1 };

            

            Console.WriteLine(answer);
        }
    }
               
               
               
}
