using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016
{
    public class Solution
    {
        public string solution(int a, int b)
        {
            DateTime date = new DateTime(2016, a, b);

            //DayOfWeek => 해당 요일 가지고옴
            //Substring(index, length) 0부터 lenght만큼 자른다
            //ex) Tuesday 앞에 3개만.Substring(0,3) => Tue
            return date.DayOfWeek.ToString().Substring(0, 3).ToUpper();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string date = sol.solution(4, 5);
            Console.WriteLine(date);
        }
    }
}
