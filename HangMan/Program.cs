using System;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            GameHistory bestGame = null;

            while(true) {
                Game game = new Game();
                String[] messages = new string[2];

                if (bestGame == null)
                {
                    if (game.won)
                    {
                        bestGame = new GameHistory(game);

                        messages[0] = "Best game yet:";
                        messages[1] = bestGame.word + " in " + bestGame.turns + " turns.";

                        Console.SetCursorPosition(0, Console.WindowHeight - (messages.Length - 1) - 1);
                        Console.WriteLine(messages[0]);
                        Console.Write(messages[1]);
                    }
                } else
                {
                    bool betterGame = game.turns < bestGame.turns || (game.turns == bestGame.turns && game.word.Length > bestGame.word.Length);

                    if (game.won && betterGame)
                    {
                        bestGame = new GameHistory(game);
                    }

                    messages[0] = "Best game yet:";
                    messages[1] = bestGame.word + " in " + bestGame.turns + " turns.";

                    Console.SetCursorPosition(0, Console.WindowHeight - (messages.Length - 1) - 1);
                    Console.WriteLine(messages[0]);
                    Console.Write(messages[1]);
                }

                messages[0] = "Press ENTER to play again...";

                Console.SetCursorPosition(Console.WindowWidth - messages[0].Length, (Console.WindowHeight - 1) - 1);
                Console.Write(messages[0]);

                Console.SetCursorPosition(0, 3);

                do
                {
                    ConsoleKeyInfo keyPress = Console.ReadKey();

                    if (keyPress.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break;
                    }
                } while (true);
            }
        }
    }
}
