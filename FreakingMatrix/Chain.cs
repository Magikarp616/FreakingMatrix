using System;
using System.Collections.Generic;
using System.Linq;

namespace FreakingMatrix
{
    class Chain
    {
        private const int MAX_CHAIN_LENGTH = 13;


        public readonly List<Sign> signList = null;
        private Sign headSign;
        public readonly int chainLength = new Random().Next(1, MAX_CHAIN_LENGTH);

        public Chain()
        {
            headSign = new Sign(new Random().Next(Sign.MAX_LEFT_POS),
                                new Random().Next(Sign.MAX_DOWN_POS - chainLength),
                                ((char)new Random().Next(0x410, 0x44F)).ToString().ToUpper(), 
                                ConsoleColor.White);

            signList = new List<Sign>() { headSign };
        }

        public void Descent(int step)
        {
            ChangeSigns();
            signList.Add(new Sign(headSign.PosX,
                                          headSign.PosY + step,
                                          ((char)new Random().Next(0x0021, 0x007E)).ToString().ToUpper(),
                                          ConsoleColor.White));
            ChangeColor();
        }

        public void Remove()
        {
            foreach (var sign in signList)
            {
                sign.Color = ConsoleColor.Black;
                sign.Value = " ";
            }
            Print();
        }

        public void RemoveStepByStep()
        {
            signList.Where(x => x.Color != ConsoleColor.Black);
        }

        private void ChangeSigns()
        {
            foreach (var sign in signList)
            {
                sign.Value = ((char)new Random().Next(0x0021, 0x007E)).ToString().ToUpper();
            }
        }

        public void Print()
        {
            foreach (var sign in signList)
            {
                sign.Print();
            }
        }

        private void ChangeColor()
        {
            foreach (var sign in signList)
            {
                sign.Color = ConsoleColor.DarkGreen;
            }
            if (signList.Count > 0)
                signList[signList.Count - 1].Color = ConsoleColor.White;

            if (signList.Count > 1)
                signList[signList.Count - 2].Color = ConsoleColor.Green;
        }
    }
}
