using LifeSimLib;
using System;

namespace LifeSim
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] FuMatrix = new int[24, 120];

            

            FuNoves grow = new(3,FuMatrix,1);
            Display(FuMatrix);
            
            while (true)
            {
                Display(FuMatrix);
                grow = new(FuMatrix);
            }


           






            void Display(int[,] Matrix)
            {
                Console.Clear();
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        if(Matrix[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (Matrix[i,j] == 2)
                        {
                            Console.ForegroundColor= ConsoleColor.Yellow;
                        }
                        else if (Matrix[i, j] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ResetColor();
                        }
                        Console.Write(Matrix[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
}