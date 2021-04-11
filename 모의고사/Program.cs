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
            int[] nRules1 = new int[] { 1, 2, 3, 4, 5 };
            int[] nRules2 = new int[] { 2, 1, 2, 3, 2, 4, 2, 5 };
            int[] nRules3 = new int[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, };
            int[] nScores = new int[3];

            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == nRules1[i % nRules1.Length]) ++nScores[0];
                if (answers[i] == nRules2[i % nRules2.Length]) ++nScores[1];
                if (answers[i] == nRules3[i % nRules3.Length]) ++nScores[2];
            }

            List<int> lstAnswer = new List<int>();
            if (nScores[0] == nScores.Max()) lstAnswer.Add(1);
            if (nScores[1] == nScores.Max()) lstAnswer.Add(2);
            if (nScores[2] == nScores.Max()) lstAnswer.Add(3);

            return lstAnswer.ToArray();
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
