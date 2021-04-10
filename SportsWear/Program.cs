using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsWear
{
    public class Solution
    {
        public int solution(int n, int[] lost, int[] reserve)
        {
            

            // 체육복이 한개씩 있다고 가정하고 시작하기 
            // {0, 0, 0, 0, 0 ..}
            int[] sportsWearChecker = new int[n];

            // 배열 값에 1 넣어주기
            // { 1, 1, 1, 1, 1 ..}
            for (int i = 0; i < n; i++)
            {
                sportsWearChecker[i] = 1;
            }

            // 잃어버린 학생 배열 값 0으로 만들기 ex) 2, 4번학생
            // {1, 0, 1, 0, 1 ..}
            for (int i = 0; i < lost.Length; i++)
            {
                sportsWearChecker[lost[i] - 1]--;
            }

            // 여벌 가지고 있는 학생 배열 값 2로 만들기 ex) 3번학생 
            // {1, 0, 2, 0, 1 ..}
            for (int i = 0; i < reserve.Length; i++)
            {
                sportsWearChecker[reserve[i] - 1]++;
            }

            // 체육복을 앞에 학생에게 준다고 가정
            for (int i = 0; i < sportsWearChecker.Length - 1; i++)
            {
                // |앞학생 - 뒷학생| = 2가 나오면 
                if (Math.Abs(sportsWearChecker[i] - sportsWearChecker[i + 1]) == 2)
                {
                    //앞 학생 0 => 1
                    sportsWearChecker[i] = 1;
                    //뒷 학생 2 => 1
                    sportsWearChecker[i + 1] = 1;
                }
            }

            // 체육복 없는 학생 숫자 체크하기
            int count = 0;
            for (int i = 0; i < sportsWearChecker.Length; i++)
            {
                if(sportsWearChecker[i] == 0)
                {
                    count++;
                }
            }

            return sportsWearChecker.Length - count;
            

            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[] lost = { 2, 4 };
            int[] reserve = { 3 };

            Solution sol = new Solution();
            int result = sol.solution(n, lost, reserve);
            Console.Write(result + " ");
        }
    }
}
