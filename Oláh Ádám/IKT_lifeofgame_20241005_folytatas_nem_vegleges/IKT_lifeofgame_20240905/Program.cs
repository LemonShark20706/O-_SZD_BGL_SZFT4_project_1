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
        Prey[,] nyuls = nyul.PreyLehelyezese(15);
        Predator[,] rokaks = rokak.PredatorLehelyezese(5);

        for (int szimulacios_ciklus = 0; szimulacios_ciklus < 15; szimulacios_ciklus++)
        {
            #region Korok
            Console.WriteLine(szimulacios_ciklus+1);
            #endregion

            #region Megjelenítés
            for (int food_matrix_ind_y = 0; food_matrix_ind_y < foods.GetLength(0); food_matrix_ind_y++)
            {
                for (int food_matrix_ind_x = 0; food_matrix_ind_x < foods.GetLength(1); food_matrix_ind_x++)
                {
                    try
                    {
                        Console.Write(rokaks[food_matrix_ind_y, food_matrix_ind_x].lenyKepe + "R");
                    }
                    catch
                    {
                        try
                        {
                            Console.Write(nyuls[food_matrix_ind_y, food_matrix_ind_x].lenyKepe + "N");
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

            #region Mozgás
            rokak.Nyomkovetes(rokaks);
            #endregion

            Console.ReadLine();
            Console.Clear();
        }
    }
}