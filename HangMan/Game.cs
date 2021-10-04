using System;
namespace HangMan
{
    public class Game
    {
        public String word;
        public int turns = 0;
        public bool won = false;

        Judge judge;

        public Game()
        {
            int lives = 7;

            Console.Write("Enter a word: ");

            Console.ForegroundColor = ConsoleColor.Black;
            word = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            HangMan hangMan = new HangMan();

            Console.WriteLine("Guess 1 letter at a time: ");

            char[] solution = word.ToCharArray();

            judge = new Judge(solution);

            judge.displayGuessed();

            while (!judge.guessedAll(judge.getGuesses()) && lives > 0)
            {
                int[] cursor = new int[] { Console.CursorLeft, Console.CursorTop };
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(cursor[0], cursor[1]);
                    continue;
                }

                char input = key.KeyChar;
                bool correct = false;

                for (int i = 0; i < solution.Length; i++)
                {
                    if (input == solution[i])
                    {
                        if ((int)judge.getGuesses()[i] == 0)
                        {
                            judge.insertGuess(i, input);
                            correct = true;
                        }
                    }
                }

                if (correct == true)
                {
                    judge.displayGuessed();
                }
                else
                {
                    lives--;

                    hangMan.drawNext();
                }

                this.turns++;
            }

            won = lives > 0;

            if (won)
            {
                hangMan.gameWon();
            }
            else
            {
                hangMan.gameDied();
                judge.displaySolution();
            }
        }
    }
}
