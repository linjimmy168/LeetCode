using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    public class stringClass
    {

        /// <summary>
        /// 13. Roman to Integer
        /// 
        ///  Console.WriteLine(stringClass.RomanToInt("MCMXCVIMM"));
        ///  Console.Read();
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'I': result += 1; break;
                    case 'V': result += 5; break;
                    case 'X': result += 10; break;
                    case 'L': result += 50; break;
                    case 'C': result += 100; break;
                    case 'D': result += 500; break;
                    case 'M': result += 1000; break;
                }
            }
            return result;
        }


        private static string[] mapping = new string[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
        public static IList<string> LeeterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new List<string>();

            Queue<string> ans = new Queue<string>();

            ans.Enqueue("");

            for(int i = 0; i < digits.Length; i++) //此迴圈控制位數
            {
                int x = digits[i] - '0';     //抓出目前位數 的數字
                while(ans.Peek().Length == i)  //確定目前 queue(最上面位數等於我目前要增加的)
                {
                    string t = ans.Dequeue();  //抓出目前要增加的位數
                    foreach (char s in mapping[x]) //抓出對應的英文字
                        ans.Enqueue(t + s);     //append 應增加的位數 + 對應的英文字
                }
            }

            return ans.ToList();
        }
    }
}
