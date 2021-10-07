using System;
namespace HangMan
{
    public class Judge
    {
        char[] solution;
        char[] guesses;

        static int[] guessedPos = new int[] { Console.WindowWidth / 2, (Console.WindowHeight / 2) + 15 };
        static int[] solutionPos = new int[] { guessedPos[0], guessedPos[1] + 1 };

        private static char[] guessedString(char[] guesses)
        {
            char[] result = new char[guesses.Length];

            for (int i = 0; i < guesses.Length; i++)
            {
                if ((int)guesses[i] == 0)
                {
                    result[i] = '_';
                }
                else
                {
                    result[i] = guesses[i];
                }
            }

            return result;
        }

        public bool guessedAll(char[] guesses)
        {
            int correct = 0;

            for (int i = 0; i < solution.Length; i++)
            {
                if (solution[i] == guesses[i])
                {
                    correct++;
                }
            }

            return correct == solution.Length;
        }

        public void insertGuess(int i, char guess)
        {
            guesses[i] = guess;
        }

        public char[] getGuesses()
        {
            return this.guesses;
        }

        public void displayGuessed()
        {
            int[] oldPosition = { Console.CursorLeft, Console.CursorTop };
            string text = String.Join(' ', guessedString(guesses));


            Console.SetCursorPosition(guessedPos[0], guessedPos[1]);
            Console.Write(text);
            Console.SetCursorPosition(oldPosition[0], oldPosition[1]);
        }

        public void displaySolution()
        {
            int[] oldPosition = { Console.CursorLeft, Console.CursorTop };
            string text = String.Join(' ', guessedString(solution));


            Console.SetCursorPosition(solutionPos[0], solutionPos[1]);
            Console.Write(text);
            Console.SetCursorPosition(oldPosition[0], oldPosition[1]);
        }

        public Judge(char[] solution)
        {
            this.solution = solution;
            this.guesses = new char[solution.Length];
        }
    }
}
