using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSim
{
    public class Functions
    {
        
        public string author {get; init;}

        public Functions(string logo)
        {
            
            author = logo;
        }

        public void Kerdes(List<string> Valasz,string Question, string[] Answers, ConsoleColor KerdesSzin = ConsoleColor.White, ConsoleColor KerdesHatter = ConsoleColor.Black, ConsoleColor ValaszHatter = ConsoleColor.Black, ConsoleColor ValaszSzin = ConsoleColor.White)
        {
            int Answer = 0;
            bool Exit = false;

            Console.CursorVisible = false;

            while (!Exit)
            {
                Console.ForegroundColor = KerdesSzin;
                Console.BackgroundColor = KerdesHatter;
                // Fő kérdés
                Console.Write(Question);
                Console.ResetColor();
                for (int i = 0; i < Answers.Length; i++)
                {
                    if (i == Answer)
                    {
                        Console.Write("\x1b[4m");
                        // Ha kivan választva a válasz
                        Console.Write($"{Answers[i]}");
                    }
                    else
                    {
                        Console.Write("\x1b[24m");
                        // Egyébb válasz
                        Console.Write($"{Answers[i]}");
                    }
                    Console.Write("\x1b[24m");
                    if (i < Answers.Length - 1)
                    {
                        // Elválasztás
                        Console.Write(" \\ ");
                    }
                }
                Console.ResetColor();
                Select();
                Console.SetCursorPosition(0, Console.CursorTop);

                // Kiírunk annyi szóközt, amennyi a konzol szélessége
                Console.Write(new string(' ', Console.WindowWidth));

                // Visszaállítjuk a kurzort a sor elejére
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            void SorCsere()//Ez törli vissza és írja ki a végén 
            {
                Console.SetCursorPosition(0, Console.CursorTop);

                // Kiírunk annyi szóközt, amennyi a konzol szélessége
                Console.Write(new string(' ', Console.WindowWidth));

                // Visszaállítjuk a kurzort a sor elejére
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.ForegroundColor = KerdesSzin;
                Console.BackgroundColor = KerdesHatter;
                Console.Write($"{Question}");
                Console.BackgroundColor = ValaszHatter;
                Console.ForegroundColor = ValaszSzin;
                Valasz.Add(Answers[Answer]);
                Console.Write($" {Answers[Answer]} ");
                Console.ResetColor();
                Console.WriteLine();
            }

            void Select()
            {
                ConsoleKeyInfo gomb = Console.ReadKey();
                if (gomb.Key == ConsoleKey.Enter)
                {
                    Exit = true;
                    SorCsere();
                }
                else if (gomb.Key == ConsoleKey.A || gomb.Key == ConsoleKey.LeftArrow)
                {
                    if (Answer - 1 >= 0)
                    {
                        Answer--;
                    }
                }
                else if (gomb.Key == ConsoleKey.D || gomb.Key == ConsoleKey.RightArrow)
                {
                    if (Answer + 1 <= Answers.Length - 1)
                    {
                        Answer++;
                    }
                }
            }
        }


        public void Settings()
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

                if (gomb.Key == ConsoleKey.Enter)
                {
                    bool isValid = valtozok.Where(x => x == "").Count() > 0;
                    if (!isValid)
                    {
                        exit = true;
                        Inditas();
                    }

                }

                else if (gomb.Key == ConsoleKey.Escape)
                {
                    exit = false;
                    try
                    {
                        Menu();
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



        public void Menu()
        {
            string[] Szintek = { "Egyedi config", "Indítás" };
            Action[] funkciok = { Settings, Inditas };

            #region menu

            bool exit = true;
            int Diff = 0;
            while (exit)
            {

                string spacing = "\t\t\t";


                Console.Clear();
                DisplayIntro(author, spacing);

                Print(spacing);
                ConsoleKeyInfo gomb = Console.ReadKey();
                if (gomb.Key == ConsoleKey.Escape || gomb.Key == ConsoleKey.Enter)
                {
                    exit = false;
                    try
                    {
                        funkciok[Diff].Invoke();
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
                        Diff++;
                    }
                }
                else if (gomb.Key == ConsoleKey.W || gomb.Key == ConsoleKey.UpArrow)
                {
                    if (Diff - 1 >= 0)
                    {
                        Diff--;
                    }
                }

            }

            void Print(string spaceing)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{spaceing}\t\t     \x1b[3mFőmenu indítási opciók\x1b[0m\n");

                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╭".PadRight(30, '─')}╮");

                for (int i = 0; i < Szintek.Length; i++)
                {
                    Console.Write(spaceing + "\t\t  ");
                    if (i == Diff)
                    {

                        Console.Write($"\u001b[91m│\t   \x1b[93m> \x1b[92m{Szintek[i]}\x1b[39m{"".PadRight(19 - Szintek[i].Length, ' ')}\u001b[91m│");
                    }
                    else
                    {
                        Console.Write($"\u001b[91m│\t   \x1b[39m{Szintek[i]}{"".PadRight(21 - Szintek[i].Length, ' ')}\u001b[91m│");
                    }
                    Console.WriteLine();
                    Console.ResetColor();

                }
                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╰".PadRight(30, '─')}╯");
                Console.ResetColor();
            }
            #endregion
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


        void Inditas()
        {
            Console.Clear();
            Console.WriteLine(1);

        }
    }
}
