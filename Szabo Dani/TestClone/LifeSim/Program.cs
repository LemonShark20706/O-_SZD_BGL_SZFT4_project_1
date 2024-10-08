using LifeSimLib;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace LifeSim
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const string author = "                    ██╗     ██╗███████╗███████╗                                              \r\n                    ██║     ██║██╔════╝██╔════╝                                              \r\n                    ██║     ██║█████╗  █████╗                                                \r\n                    ██║     ██║██╔══╝  ██╔══╝                                                \r\n                    ███████╗██║██║     ███████╗                                              \r\n                    ╚══════╝╚═╝╚═╝     ╚══════╝                                              \r\n                                                                         \r\n███████╗██╗███╗   ███╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗ \r\n██╔════╝██║████╗ ████║██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗\r\n███████╗██║██╔████╔██║██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝\r\n╚════██║██║██║╚██╔╝██║██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗\r\n███████║██║██║ ╚═╝ ██║╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║\r\n╚══════╝╚═╝╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝";


            List<string> Valasz = new List<string>();

            Functions rendszerek = new(author);



            void Startup()
            {
                rendszerek.Kerdes(Valasz,"Milyen OP-rendszert használsz: ", ["Windows", "Linux"], ConsoleColor.Cyan);
                rendszerek.Kerdes(Valasz,"Az emoji-kat megtudod jeleníteni: ", ["Igen", "Nem"], ConsoleColor.Cyan);

                for (int i = 0; i < 20; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("#");
                    Console.ResetColor();
                    Thread.Sleep(30);
                }

                rendszerek.Menu();
            }

            Startup();
            

            
            foreach (string s in Valasz)
            {
                Console.WriteLine(s);
            }
            


            





            

            














            int Sor = 24;
            int Oszlop = 120;
            // int MinNyulak = 40;//Kezdő nyulak amit generál
            // int MaxNyulErtek = 3; //Max amennyit ehet
            // int FuNovekedesArany = 300;//Milyen gyakorisággal nőnek a füvek


            int MinNyulak = 40;
            int MaxNyulErtek = 3;
            int FuNovekedesArany = 300;

            int AlapFu = 1;
            int MaxFuErtek = 3;

            int MinRokak = 4; //Kezdő rokák spawnolasa
            int MaxRokaErtek = 20; //Max amennyit ehet


            int[,] FuMatrix = new int[Sor, Oszlop];

            int[,] NyulMatrix = new int[Sor, Oszlop];

            int[,] RokaMatrix = new int[Sor, Oszlop];

            FuNoves grow = new(MaxFuErtek, FuMatrix, AlapFu);
            NyulMovment Nyul = new(NyulMatrix, MinNyulak, MaxNyulErtek);

            //FuNoves grow = new(3,FuMatrix,1);
            //Display(FuMatrix);
            #region funoves_Test
            //while (true)
            //{
            //    Display(FuMatrix);
            //    grow = new(FuMatrix);
            //}
            #endregion
            #region (Nyulmozgas + Eletter)_Test

            //ConsoleKeyInfo gomb = Console.ReadKey();

            //while (gomb.Key != ConsoleKey.Q)
            //{
            //    Console.Clear();
            //    Console.WriteLine();
            //    Nyul.Lepes(NyulMatrix, FuMatrix);
            //    grow = new(FuMatrix, FuNovekedesArany);
            //    Display(NyulMatrix);
            //    gomb = Console.ReadKey();



            //}
            //Console.WriteLine("Össz halott nyulak száma: "+Nyul.OsszHaltNyul);
            //Console.WriteLine("Össz született nyulak száma: "+Nyul.OsszSzuletettNyul);
            //Console.WriteLine("Össz nyulak száma: "+Nyul.OsszNyul(NyulMatrix));
            #endregion



            Console.WriteLine("");

            void Display(int[,] Matrix)
            {
                
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
            }
        }
    }
}