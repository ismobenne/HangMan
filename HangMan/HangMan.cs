using System;

namespace HangMan
{
    public class HangMan
    {
        static int[] rootPos = new int[] { Console.WindowWidth / 2, Console.WindowHeight / 2 };
        static int[] textPos = new int[] { Console.WindowWidth / 2, (Console.WindowHeight / 2) + 20 };

        int[] pencilTip;
        int i = 0;

        public HangMan()
        {
            this.pencilTip = rootPos;
        }
            
        public void gameWon()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(textPos[0], textPos[1]);
            Console.WriteLine("You guessed the word!");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void gameDied()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(textPos[0], textPos[1]);
            Console.WriteLine("You died!");

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void drawStand()
        {
            Console.SetCursorPosition(pencilTip[0], pencilTip[1]);
            Console.Write("------");
        }

        private void drawPole()
        {
            Console.SetCursorPosition(pencilTip[0] += 2, pencilTip[1] -= 1);

            for (int i = 0; i < 10; i++)
            {
                Console.Write("|");
                Console.SetCursorPosition(pencilTip[0], pencilTip[1] -= 1);
            }
        }

        private void drawRoof()
        {
            Console.SetCursorPosition(pencilTip[0], pencilTip[1]);
            Console.Write("------------");
            Console.SetCursorPosition(pencilTip[0] += ("------------".Length - 1), pencilTip[1]);
        }

        private void drawRope()
        {
            for (int i = 0; i < 2; i++)
            {

                Console.SetCursorPosition(pencilTip[0], pencilTip[1] += 1);
                Console.Write("|");
            }
        }

        private void drawHead()
        {
            Console.SetCursorPosition(pencilTip[0] -= 1, pencilTip[1] += 1);
            Console.Write("<<)");
        }

        private void drawBody()
        {
            Console.SetCursorPosition(pencilTip[0] += 1, pencilTip[1] += 1);
            Console.Write("#");

            Console.SetCursorPosition(pencilTip[0] -= 4, pencilTip[1] += 1);
            Console.Write("=-- # --=");

            Console.SetCursorPosition(pencilTip[0] += 4, pencilTip[1] += 1);
            Console.Write("#");
        }

        private void drawLegs()
        {

            Console.SetCursorPosition(pencilTip[0] -= 1, pencilTip[1] += 1);
            Console.Write("/ \\");

            Console.SetCursorPosition(pencilTip[0] -= 2, pencilTip[1] += 1);
            Console.Write("_/   \\_");
        }

        public void drawNext()
        {
            int[] cursor = { Console.CursorLeft, Console.CursorTop };

            switch (i)
            {
                case 0:
                    this.drawStand();
                    break;

                case 1:
                    this.drawPole();
                    break;

                case 2:
                    this.drawRoof();
                    break;

                case 3:
                    this.drawRope();
                    break;

                case 4:
                    this.drawHead();
                    break;

                case 5:
                    this.drawBody();
                    break;

                case 6:
                    this.drawLegs();
                    break;
            }

            Console.SetCursorPosition(cursor[0], cursor[1]);

            i++;
        }
    }
}
