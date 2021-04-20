using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPosNeg
{
    public class Solution
    {
        public int solution(int[] absolutes, bool[] signs)
        {
            List<int> list = new List<int>();
            int reuslt = 0;
            for (int i = 0; i < absolutes.Length; i++)
            {
                if (signs[i] == false)
                {
                    list.Add(absolutes[i] * -1);
                }
                else
                {
                    list.Add(absolutes[i]);
                }
            }
             
            for (int i = 0; i < list.Count; i++)
            {
                reuslt += list[i];
            }

            return reuslt;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] absolutes = { 4, 7, 12 };
            bool[] signs = { true, false, true };
            Solution sol = new Solution();
            int result = sol.solution(absolutes, signs);
            Console.WriteLine(result);
        }
    }
}
