using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lifeForms_lib
{
    public class Lenyek
    {
        Random r = new Random();

        #region perdator helyzete
        public Predator[,] PredatorLehelyezese(int rokak)
        {
            Predator[,] predator_jatekter_logika_Matrix = new Predator[26, 118];
            for (int roka_i = 0; roka_i < rokak; roka_i++)
            {
                int x = r.Next(0, 118);
                int y = r.Next(0, 26);

                for (int i = 0; i < predator_jatekter_logika_Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < predator_jatekter_logika_Matrix.GetLength(1); j++)
                    {
                        Predator roka = new Predator();
                        if (i == y && j == x)
                        {
                            predator_jatekter_logika_Matrix[i, j] = roka;
                        }
                    }
                }
            }
            return predator_jatekter_logika_Matrix;
        }
        #endregion

        #region predator pathFinding
        public Predator[,] Nyomkovetes(Predator[,] regi_predator_jatekter_logika_Matrix)
        {

            for (int i = 0; i < regi_predator_jatekter_logika_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < regi_predator_jatekter_logika_Matrix.GetLength(1); j++)
                {
                    try
                    {
                        if (regi_predator_jatekter_logika_Matrix[i, j].Lenytipusa == "predator")
                        {
                            int lepes = r.Next(1,4);
                            Console.WriteLine($"\n1. kiírás.:\n\t- {regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota}\n\t- {regi_predator_jatekter_logika_Matrix[i, j].lenyKaja}\n\t- {lepes}");
                            if (regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota - lepes >= 0)
                            {
                                regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota = regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota - lepes;
                            }
                            else
                            {
                                regi_predator_jatekter_logika_Matrix[i, j].lenyKaja = regi_predator_jatekter_logika_Matrix[i, j].lenyKaja - (lepes - regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota);
                            }
                            Console.WriteLine($"2. kiírás.:\n\t- {regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota}\n\t- {regi_predator_jatekter_logika_Matrix[i, j].lenyKaja}");
                        }
                    }
                    catch { }
                }
            }
            return regi_predator_jatekter_logika_Matrix;
        }
        #endregion

        #region prey helyzete
        public Prey[,] PreyLehelyezese(int nyulak)
        {
            Prey[,] prey_jatekter_logika_Matrix = new Prey[26, 118];
            for (int nyulak_i = 0; nyulak_i < nyulak; nyulak_i++)
            {
                int x = r.Next(0, 118);
                int y = r.Next(0, 26);

                for (int i = 0; i < prey_jatekter_logika_Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < prey_jatekter_logika_Matrix.GetLength(1); j++)
                    {
                        Prey nyul = new Prey();
                        if (i == y && j == x)
                        {
                            prey_jatekter_logika_Matrix[i, j] = nyul;
                        }
                    }
                }
            }
            return prey_jatekter_logika_Matrix;
        }
        #endregion

        #region food helyzete
        public Food[,] FoodLehelyezese()
        {
            Food[,] kaja_jatekter_logika_Matrix = new Food[26, 118];
            
            for (int i = 0; i < kaja_jatekter_logika_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < kaja_jatekter_logika_Matrix.GetLength(1); j++)
                {
                    Food kaja = new Food();
                    kaja_jatekter_logika_Matrix[i, j] = kaja;
                }
            }
            return kaja_jatekter_logika_Matrix;
        }
        #endregion

        #region
        #endregion
    }
}