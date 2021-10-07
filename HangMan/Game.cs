using System;
namespace HangMan
{
    public class Game
    {
        public String word;
        public int turns;

        private int lives;

        Judge judge;

        public bool play()
        {
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
                    // if guessed letter is in the solution and the guess is unique
                    if (input == solution[i] && judge.getGuesses()[i] == new char())
                    {
                        judge.insertGuess(i, input);
                        correct = true;
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

            if (lives > 0)
            {
                hangMan.gameWon();
                return true;
            }
            else
            {
                hangMan.gameDied();
                judge.displaySolution();
                return false;
            }
        }

        public Game(String word)
        {
            this.word = word;
            this.turns = 0;
            this.lives = 7;
        }
    }
}
