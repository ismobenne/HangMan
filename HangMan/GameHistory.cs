using System;
namespace HangMan
{
    public class GameHistory
    {
        public String word;
        public int turns;

        public GameHistory(Game game)
        {
            this.word = game.word;
            this.turns = game.turns;
        }
    }
}
