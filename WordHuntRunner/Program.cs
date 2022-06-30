using System;
using WordHuntSolver;

namespace WordHuntRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "C:\\Users\\VishnuM\\source\\repos\\WordHunt\\WordHuntSolver\\CollinsScrabbleWords.txt";
            
            Solver sl = new Solver(address);
            Console.WriteLine("Enter Input a row at a time");
            char[,] matrix = new char[4, 4];
            for (int i = 0; i < 4; i++)
            {
                var inp = Console.ReadLine().ToUpper();
                int j = 0;
                foreach (char c in inp)
                {
                    matrix[i, j] = c;
                    j++;
                }
            }
            Outputter o = new Outputter(matrix);
            Console.WriteLine("Your input.");
            
            var actual = sl.SolveWordHunt(matrix, 4);
            Console.WriteLine(Outputter.PrintMatrix(matrix));
            foreach (var ProgWord in actual)
            {
                Console.WriteLine(ProgWord.ToString());
                Console.WriteLine(Outputter.PrintMatrix(o.CreateMatrixFromArray(ProgWord.letterList)));
            }
        }
    }
}
