using System;
using System.Collections.Generic;
using System.Text;

namespace WordHuntSolver
{
    public class Outputter
    {
        char[,] board;

        public Outputter(char[,] matrix)
        {
            board = matrix;
        }

        public static string PrintMatrix(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);
                    sb.Append(" ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public char[,] CreateMatrixFromArray(List<Tuple<int, int>> letterList)
        {
            char[,] res = new char[board.GetLength(0), board.GetLength(1)];
            foreach (Tuple<int, int> el in letterList)
            {
                (var i, var j) = el;
                res[i, j] = board[i, j];
            }
            return res;
        }
    }
}
