using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTestGiveUp
{
    public class Solution
    {
        public int[] solution(int[] answers)
        {
            //수포자가 찍는 방식
            int[] student1 = { 1, 2, 3, 4, 5, }; // 5개 패턴
            int[] student2 = { 2, 1, 2, 3, 2, 4, 2, 5 }; // 8개 반복 패턴
            int[] student3 = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 }; //10개 반복 패턴

            //정답수 카운트 할수 있는 배열 만들기 
            //나중에 가장 많이 맞힌 사람 비교해야하니깐 배열로 만듬
            int[] rightAnswerNum = new int[3];

            //답안지랑 찍은거랑 비교
            for (int i = 0; i < answers.Length; i++)
            {
                // 1번학생 답안지 비교
                if (student1[i % 5] == answers[i])
                {
                    // 1학생 정답수 체크(카운트하기)
                    rightAnswerNum[0]++;
                }

                // 2번학생 답안지 비교
                if (student2[i % 8] == answers[i])
                {
                    // 1학생 정답수 체크(카운트하기)
                    rightAnswerNum[1]++;
                }

                // 3번학생 답안지 비교
                if (student3[i % 10] == answers[i])
                {
                    // 1학생 정답수 체크(카운트하기)
                    rightAnswerNum[2]++;
                }
            }

            // 정답수 비교할 리스트 만들기
            List<int> bestStudents = new List<int>();

            // 정답수 비교
            for (int i = 0; i < 3; i++)
            {
                int bestScore = rightAnswerNum.Max();

                if (bestScore == rightAnswerNum[i])
                {
                    bestStudents.Add(i+1);
                }
            }
            bestStudents.Sort();

            return bestStudents.ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] answer = { 1, 3, 2, 4, 2, 1, 3, 2, 4, 2, 1, 3, 2, 4, 2 };
            Solution sol = new Solution();
            int[] result = sol.solution(answer);
            
            for(int i = 0; i < result.Length; i++)
            {

            Console.Write(result[i] +", ");
            }
        }
    }
}
