using System;
using System.Threading;

namespace FreakingMatrix
{
    class Program
    {
        public const int MAX_TREADS = 60;



        public static object locker = new object();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            

            for (int i = 0; i < MAX_TREADS; i++)
            {
                Thread thread = new Thread(Method3);
                thread.Start();
            }

            Console.ReadKey();
        }

        public static void Method2()
        {
            while (true)
            {
                Chain chain = new Chain();
                for (int i = 0; i < chain.chainLength; i++)
                {
                    chain.Descent(i);
                    Thread.Sleep(50);
                    lock (locker)
                    {
                        //Thread.Sleep(500);
                        chain.Print();
                    }
                }

                lock (locker)
                {
                    chain.Remove();
                }
            }
        }

        public static void Method3()
        {
            while (true)
            {
                Chain chain = new Chain();
                for (int i = 0; i < chain.chainLength; i++)
                {

                    chain.Descent(i);
                    Thread.Sleep(50);
                    lock (locker)
                    {
                        //Thread.Sleep(500);
                        chain.Print();
                    }
                }

                for (int i = 0; i < chain.chainLength + 1; i++)
                {
                    chain.signList[i].Color = ConsoleColor.Black;
                    Thread.Sleep(50);
                    lock (locker)
                    {
                        chain.Print();
                    }
                }
                
            }
        }
    }
}
