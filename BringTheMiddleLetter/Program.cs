using System;

namespace BringTheMiddleLetter
{
    class Program
    {
        public class Solution
        {
            public string solution(string s)
            {
                string answer = "";
                int center = s.Length / 2;
                if (s.Length % 2 == 0)
                {
                    answer = s[center - 1].ToString() + s[center].ToString(); 
                }
                else
                {
                   answer = s[center].ToString();
                }
                return answer;
            }

        }
        /*
        public string solution(string s)
        {
            int n = (s.Length + 1) % 2;
            int l = s.Length / 2 - n;
            return s.Substring(l, n + 1);
        }
        */
        static void Main(string[] args)
        {
            string s = "abcde";
            Solution sol = new Solution();

            String result = sol.solution(s);
            Console.WriteLine(result);
        }
    }
}






