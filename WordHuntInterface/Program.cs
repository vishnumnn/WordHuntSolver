using System;
using WordHuntSolver;
using Outputter;

namespace WordHuntInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Input a row at a time");
            char[,] matrix = new char[4, 4];
            for(int i = 0; i < 4; i++)
            {
                var inp = Console.ReadLine();
                int j = 0;
                foreach (char c in inp)
                {
                    matrix[i,j] = c;
                    j++;
                }
            }
            Console.WriteLine("Your input.");
            Outputter o = new Outputter(matrix);

            Console.WriteLine();
            var actual = sl.SolveWordHunt(matrix, 4);
            foreach(var ProgWord in actual)
            {
                Outputter.PrintMatrix(Outputter.CreateMatrixFromArray(ProgWord.letterList));
                Console.WriteLine();
            }
        }
    }
}
