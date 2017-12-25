using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class HashTable
    {
        /// <summary>
        /// 1.Two Sum (但此解法無解決Dictionary 重複值)
        /// Console.WriteLine(HashTable.TwoSum(new int[]{ 3,2,4},6));
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int[] result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    int temp;
                    dic.TryGetValue(target - nums[i], out temp);
                    result[0] = i;
                    result[1] = temp;
                    return result;
                }
                dic.Add(nums[i],i);
            }
            throw new ArgumentException("No");
        }

        /// <summary>
        /// 36. Valid Sudoku
        /// 
        /// Console.WriteLine(HashTable.IsValidSudoku(new char[,] { { '.', '8', '7', '6', '5', '4', '3', '2', '1' }, { '2', '.', '.', '.', '.', '.', '.', '.', '.' }, { '3', '.', '.', '.', '.', '.', '.', '.', '.' }, { '4', '.', '.', '.', '.', '.', '.', '.', '.' }, { '5', '.', '.', '.', '.', '.', '.', '.', '.' }, { '6', '.', '.', '.', '.', '.', '.', '.', '.' }, { '7', '.', '.', '.', '.', '.', '.', '.', '.' }, { '8', '.', '.', '.', '.', '.', '.', '.', '.' }, { '9', '.', '.', '.', '.', '.', '.', '.', '.' } }));
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool IsValidSudoku(char[,] board)
        {
            HashSet<string> seen = new HashSet<string>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char number = board[i, j];
                    if (number != '.')
                    {
                        if (!seen.Add(number + "in row" + i) ||    //hashset加入失敗就代表這一列有這一筆數字
                           !seen.Add(number + "in column" + j) ||
                           !seen.Add(number + "in block" + i / 3 + "-" + j / 3))
                            return false;
                    }
                }
            }
            return true;
        }


        #region 37 Sudoku Solver
        /// <summary>
        /// 37 Sudoku Solver
        ///  char[,] board = new char[,] { { '.', '.', '9', '7', '4', '8', '.', '.', '.' }, { '7', '.', '.', '.', '.', '.', '.', '.', '.' }, { '.', '2', '.', '1', '.', '9', '.', '.', '.' }, { '.', '.', '7', '.', '.', '.', '2', '4', '.' }, { '.', '6', '4', '.', '1', '.', '5', '9', '.' }, { '.', '9', '8', '.', '.', '.', '3', '.', '.' }, { '.', '.', '.', '8', '.', '3', '.', '2', '.' }, { '.', '.', '.', '.', '.', '.', '.', '.', '6' }, { '.', '.', '.', '2', '7', '5', '9', '.', '.' } };
        /// HashTable.SolveSudoku(board);
        /// </summary>
        /// <param name="board"></param>
        public static void SolveSudoku(char[,] board)
        {
            if (board == null || board.Length == 0)
                return;
            Solve(board);
        }

        /// <summary>
        /// 解決方法: 
        /// 1.判斷1~9數字 是否在此合理
        /// 2.合理就寫入進去,
        /// 3.再丟入判斷方法
        /// 若數字合理,但不是正確解(因為已經都窮舉了);將此數字清掉;換下一個數字
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private static bool Solve(char[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++) 
                        {
                            if (IsSudoValid(board, i, j, c))  //判斷此數字是否合理
                            {
                                //此部分用於回溯值;若不合適清空換下一個
                                board[i, j] = c;
                                if (Solve(board))            
                                {
                                    return true;
                                }
                                else
                                {
                                    board[i, j] = '.';
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsSudoValid(char[,] board,int row,int column,char c)
        {
            for(int i = 0; i < 9; i++)
            {
                if (board[i, column] != '.' && board[i, column] == c) return false;
                if (board[row, i] != '.' && board[row, i] == c) return false;
                if (board[3 * (row / 3) + i / 3, 3 * (column / 3) + i % 3] != '.' && board[3 * (row / 3) + i / 3, 3 * (column / 3) + i % 3] == c)   //判斷所在block中有無重複值
                    return false;
            }
            return true;
        }
    #endregion

    }
}
