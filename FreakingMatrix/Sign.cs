using System;
using System.Collections.Generic;
using System.Text;

namespace FreakingMatrix
{
    class Sign
    {
        public static int MAX_LEFT_POS = Console.WindowWidth;
        public static int MAX_DOWN_POS = Console.WindowHeight;


        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Value { get; set; }
        public ConsoleColor Color { get; set; }

        public Sign(int posX, int posY, string value, ConsoleColor color)
        {
            PosX = posX;
            PosY = posY;
            Value = value;
            Color = color;
        }

        public void Print()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = Color;
            Console.Write(Value);
        }
    }
}
