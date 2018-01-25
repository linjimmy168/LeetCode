using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Test
    {
        public static void Test2()
        {
            List<int> list = new List<int>() { 1,2,3,4};
            var temp = list[2];
            list[2] = list[1];
            list[1] = temp;
        }
    }
}
