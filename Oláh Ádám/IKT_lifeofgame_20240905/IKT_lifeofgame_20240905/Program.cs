using lifeForms_lib;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Random r = new Random();

        Lenyek repa = new Lenyek();
        Lenyek nyul = new Lenyek();
        Lenyek rokak = new Lenyek();

        Food[,] foods = repa.FoodLehelyezese();
        
        Console.Write("Mennyi nyúl legyen?.: ");
        int nyulakSzama = int.Parse(Console.ReadLine()!);
        Prey[,] nyuls = nyul.PreyLehelyezese(nyulakSzama);
        Console.Clear();

        Console.Write("Mennyi róka legyen?.: ");
        int rokakSzama = int.Parse(Console.ReadLine()!);
        Predator[,] rokaks = rokak.PredatorLehelyezese(rokakSzama);
        Console.Clear();


        Console.Write("Mennyi ciklus fusson le?.: ");
        int ciklusokSzama = int.Parse(Console.ReadLine()!);
        Console.Clear();
        for (int szimulacios_ciklus = 0; szimulacios_ciklus < ciklusokSzama; szimulacios_ciklus++)
        {
            #region Korok
            Console.WriteLine($"A szimuláció köre.: {szimulacios_ciklus + 1}");
            #endregion

            #region Megjelenítés
            for (int food_matrix_ind_y = 0; food_matrix_ind_y < foods.GetLength(0); food_matrix_ind_y++)
            {
                for (int food_matrix_ind_x = 0; food_matrix_ind_x < foods.GetLength(1); food_matrix_ind_x++)
                {
                    try
                    {
                        Console.Write(rokaks[food_matrix_ind_y, food_matrix_ind_x].lenyKepe + "R" + $"({food_matrix_ind_x};{food_matrix_ind_y})");
                    }
                    catch
                    {
                        try
                        {
                            Console.Write(nyuls[food_matrix_ind_y, food_matrix_ind_x].lenyKepe + "N" + $"({food_matrix_ind_x};{food_matrix_ind_y})");
                        }
                        catch
                        {
                            Console.Write(foods[food_matrix_ind_y, food_matrix_ind_x].lenyKaja);
                        }
                    }
                }
                Console.WriteLine();
            }
            #endregion

            #region passz
            for (int food_matrix_ind_y = 0; food_matrix_ind_y < foods.GetLength(0); food_matrix_ind_y++)
            {
                for (int food_matrix_ind_x = 0; food_matrix_ind_x < foods.GetLength(1); food_matrix_ind_x++)
                {
                    if (foods[food_matrix_ind_y, food_matrix_ind_x].lenyKaja != 3)
                    {
                        if (r.Next(1,5) == 1)
                        {
                            foods[food_matrix_ind_y, food_matrix_ind_x].lenyKaja++;
                        }
                        foods[food_matrix_ind_y, food_matrix_ind_x].lenyEletTartama++;

                        try
                        {
                            nyuls[food_matrix_ind_y, food_matrix_ind_x].lenyEletTartama++;
                        }
                        catch {}

                        try
                        {
                            rokaks[food_matrix_ind_y, food_matrix_ind_x].lenyEletTartama++;
                        }
                        catch { }
                    }
                }
            }
            #endregion

            #region Mozgás
            nyul.lepes(foods,nyuls);
            rokak.Nyomkovetes(nyuls,rokaks);
            #endregion

            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine($"A szimuláció véget ért.\n\tKapott adatok.:\n\t\t~Rókák statisztika.:\n\t\t\t- Született rókák.: {rokak.SzuletettRokak}\n\t\t\t- Mennyi róka élt.: {rokak.LetezoRokakSzama}\n\t\t\t- Rókák átlagos élet tartama.: {rokak.AtlagosRokaElettartam}\n\n\t\t~Nyulak statisztika.:\n\t\t\t- Született nyulak.: {nyul.SzuletettNyulak}\n\t\t\t- Mennyi nyulak élt.: {nyul.LetezoNyulakSzama}\n\t\t\t- Nyulak átlagos élet tartama.: {nyul.AtlagosNyulakElettartam}");
        Console.ReadLine();
    }
}