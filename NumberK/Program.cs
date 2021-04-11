using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberK
{
    public class Solution
    {
        public int[] solution(int[] array, int[,] commands)
        {
            // array 배열을 i번째 j번째 자르고싶다. 
            // i,j는 commands 2차배열 인덱스 0,1에 있다.
            // index 0, 1번이 start, end
            List<int> cutIndex = new List<int>();

            // 리턴할 정답 리스트만들기
            List<int> answer = new List<int>();

            for (int i = 0; i < commands.GetLength(0); i++)
            {
                //index값이니깐 1씩 빼준다.
                int start = commands[i, 0] - 1;
                // 시작에서 끝 이동 -> end - start ==> count
                int end = commands[i, 1] - start;

                // 자른 인덱스 안에 값 넣어주기
                // GetRange (int index, int count) index부터 count만큼 이동
                cutIndex = array.ToList<int>().GetRange(start, end);
                //정렬하기
                cutIndex.Sort();

                int result = cutIndex[commands[i, 2] - 1];
                answer.Add(result);
            }

            return answer.ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 5, 2, 6, 3, 7, 4 };
            int[,] commands = { { 2, 5, 3 }, { 4, 4, 1 }, { 1, 7, 3 } };

            Solution sol = new Solution();
            int[] result = sol.solution(array, commands);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + ", ");
            }

        }
    }
}
