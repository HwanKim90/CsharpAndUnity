using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    class Solution
    {
        public int solution(int[] nums)
        {
            int sum = 0;
            int result = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {    
                for (int j = i+1; j < nums.Length; j++)
                {
                    for (int k = j+1; k < nums.Length; k++)
                    {
                        sum = nums[i] + nums[j] + nums[k];

                        if (isPrime(sum) == true)
                        {
                            result++;
                        }
                    }
                }
            }
            

            return result;
        }

        bool isPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 7, 6, 4 };

            Solution sol = new Solution();

            int result = sol.solution(nums);
            Console.WriteLine(result);
        }
    }
}
        


