using System;

namespace HangMan
{
    class Program
    {

        static void Main(string[] args)
        {
            GameHistory bestGame = null;

            while(true) {
                Console.Clear();

                // ask the user for a word
                String word;

                Console.Write("Enter a word: ");

                Console.ForegroundColor = ConsoleColor.Black;
                word = Console.ReadLine();
                word = word.ToLower();
                Console.ForegroundColor = ConsoleColor.White;

                if (word == String.Empty)
                {
                    continue;
                }

                Console.Clear();

                Game game = new Game(word);

                // play the game and store whether the game was won
                bool won = game.play();

                String[] text = new string[2];

                if (bestGame == null)
                {
                    // if the best game does not exist yet and the player won
                    if (won)
                    {
                        bestGame = new GameHistory(game);

                        text[0] = "Best game yet:";
                        text[1] = bestGame.word + " in " + bestGame.turns + " turns.";

                        Console.SetCursorPosition(0, Console.WindowHeight - (text.Length - 1) - 1);
                        Console.WriteLine(text[0]);
                        Console.Write(text[1]);
                    }
                } else
                {
                    bool betterGame = game.turns < bestGame.turns || (game.turns == bestGame.turns && game.word.Length > bestGame.word.Length);

                    // if the player won and the game was better than the current best game
                    if (won && betterGame)
                    {
                        bestGame = new GameHistory(game);
                    }

                    text[0] = "Best game yet:";
                    text[1] = bestGame.word + " in " + bestGame.turns + " turns.";

                    Console.SetCursorPosition(0, Console.WindowHeight - (text.Length - 1) - 1);
                    Console.WriteLine(text[0]);
                    Console.Write(text[1]);
                }

                text[0] = "Press ENTER to play again...";

                Console.SetCursorPosition(Console.WindowWidth - text[0].Length, (Console.WindowHeight - 1) - 1);
                Console.Write(text[0]);

                // wait for the player to play again
                do
                {
                    ConsoleKeyInfo keyPress = Console.ReadKey();

                    if (keyPress.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                } while (true);
            }
        }
    }
}
