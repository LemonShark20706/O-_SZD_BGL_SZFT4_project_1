using LifeSimLib;
using System;

namespace LifeSim
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const string author = "                    ██╗     ██╗███████╗███████╗                                              \r\n                    ██║     ██║██╔════╝██╔════╝                                              \r\n                    ██║     ██║█████╗  █████╗                                                \r\n                    ██║     ██║██╔══╝  ██╔══╝                                                \r\n                    ███████╗██║██║     ███████╗                                              \r\n                    ╚══════╝╚═╝╚═╝     ╚══════╝                                              \r\n                                                                         \r\n███████╗██╗███╗   ███╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗ \r\n██╔════╝██║████╗ ████║██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗\r\n███████╗██║██╔████╔██║██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝\r\n╚════██║██║██║╚██╔╝██║██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗\r\n███████║██║██║ ╚═╝ ██║╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║\r\n╚══════╝╚═╝╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝";


            Settings();


            void Settings()
            {
                string[] valtozok = { "", "", "", "", "", "", "" }; // Az egyes menüpontokhoz tartozó értékek
                string[] Szintek = { "Sorok: ", "Oszlopok: ", "Kezdő Nyulak száma: ", "Max Nyulak tápértéke: ", "Fű növekedésének aránya: ", "Alap fű értéke: ", "Max fű értéke: " };



                bool exit = false;
                int Diff = 0; // Aktuális menüpont indexe

                while (!exit)
                {
                    string spacing = "\t\t\t";

                    Console.Clear();
                    DisplayIntro(author, spacing);

                    Print(spacing); // A menü megjelenítése

                    ConsoleKeyInfo gomb = Console.ReadKey();

                    if (gomb.Key == ConsoleKey.Escape || gomb.Key == ConsoleKey.Enter)
                    {
                        exit = true;
                        try
                        {
                            Inditas();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Hiányos funkció lista: {e.Message}");
                        }
                    }
                    else if (gomb.Key == ConsoleKey.S || gomb.Key == ConsoleKey.DownArrow)
                    {
                        if (Diff + 1 < Szintek.Length)
                        {
                            Diff++; // Menüpont lefelé mozgatása
                        }
                    }
                    else if (gomb.Key == ConsoleKey.W || gomb.Key == ConsoleKey.UpArrow)
                    {
                        if (Diff - 1 >= 0)
                        {
                            Diff--; // Menüpont felfelé mozgatása
                        }
                    }
                    else if (gomb.Key == ConsoleKey.Backspace && valtozok[Diff].Length > 0)
                    {
                        // Backspace esetén az aktuális menüpont változójának utolsó karakterének törlése
                        valtozok[Diff] = valtozok[Diff].Substring(0, valtozok[Diff].Length - 1);
                    }
                    else if (char.IsDigit(gomb.KeyChar))
                    {
                        // Ha a felhasználó számot nyom, akkor az aktuális menüpont változójához hozzáfűzzük a számot
                        if (valtozok[Diff].Length < 7) // Ha a szám kisseb mint 7 akkor adja hozzá
                        {
                            valtozok[Diff] += gomb.KeyChar;
                        }
                    }
                }

                void Print(string spaceing)
                {
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n{spaceing}\t  \x1b[3mItt választhatod ki az alapértékeket\x1b[0m\n");

                    Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╭".PadRight(43, '─')}╮");

                    for (int i = 0; i < Szintek.Length; i++)
                    {
                        Console.Write(spaceing + "\t\t  ");
                        if (i == Diff)
                        {
                            // Az aktuális menüpont kiemelése és a hozzá tartozó változó megjelenítése
                            Console.Write($"\u001b[91m│\t   \x1b[93m> \x1b[92m{Szintek[i]}{valtozok[i]}\x1b[39m{"".PadRight(32 - Szintek[i].Length - valtozok[i].Length, ' ')}\u001b[91m│");
                        }
                        else
                        {
                            // Nem aktuális menüpont, csak az érték megjelenítése
                            Console.Write($"\u001b[91m│\t   \x1b[39m{Szintek[i]}{valtozok[i]}{"".PadRight(34 - Szintek[i].Length - valtozok[i].Length, ' ')}\u001b[91m│");
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                    }

                    Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╰".PadRight(43, '─')}╯");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n{spaceing}\t  \u001b[3mNYILAK-kal tudsz mozogni és ENTER-el tudod fixálni/elindítani\x1b[0m\n");
                    Console.ResetColor();
                }
            }







            void DisplayIntro(string intro, string spacing)
            {
                Console.Clear();
                string[] lines = intro.Split('\n');
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (string line in lines)
                {
                    Console.WriteLine(spacing + line);
                }
                Console.ResetColor();
            }
            DisplayIntro(author, "\t\t\t");

            void Inditas()
            {
                Console.WriteLine(1);
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