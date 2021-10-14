using System;

namespace HangMan
{
    public class HangMan
    {
        static int[] pencilTip = new int[] { Console.WindowWidth/2 - 18/2, Console.WindowHeight/2 };
        static int[] announcementPos = new int[] { Console.WindowWidth/2, Console.WindowHeight / 2 + 20 };

        int i = 0;
            
        public void gameWon()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            String text = "You guessed the word!";
            Console.SetCursorPosition(announcementPos[0] - text.Length/2, announcementPos[1]);
            Console.WriteLine(text);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void gameDied()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            String text = "You died!";
            Console.SetCursorPosition(announcementPos[0] - text.Length/2, announcementPos[1]);
            Console.WriteLine(text);

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
            int[] oldPosition = { Console.CursorLeft, Console.CursorTop };

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

            Console.SetCursorPosition(oldPosition[0], oldPosition[1]);

            i++;
        }
    }
}
