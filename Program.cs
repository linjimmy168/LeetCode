using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 3, 6, 7 };
            var a = BackTracking.CombinationSum(array, 7);
            Console.Read();
        }
    }
}
