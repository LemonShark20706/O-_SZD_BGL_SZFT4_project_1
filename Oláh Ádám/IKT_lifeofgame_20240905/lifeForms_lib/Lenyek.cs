using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lifeForms_lib
{
    public class Lenyek
    {
        Random r = new Random();

        #region Statisztika
        public int SzuletettRokak = 0;
        List<Predator> LetezettRokak = new();
        public int LetezoRokakSzama => LetezettRokak.Count();
        public double? AtlagosRokaElettartam => LetezettRokak.Sum(x => x.lenyEletTartama) / LetezettRokak.Count();


        public int SzuletettNyulak = 0;
        List<Prey> LetezettNyulak = new();
        public int LetezoNyulakSzama => LetezettNyulak.Count();
        public double? AtlagosNyulakElettartam => LetezettNyulak.Sum(x => x.lenyEletTartama) / LetezettNyulak.Count();

        int MegevettRepakSzama = 0;
        int MegevettRepakErteke = 0;
        #endregion

        #region perdator helyzete
        public Predator[,] PredatorLehelyezese(int rokak)
        {
            Predator[,]? predator_jatekter_logika_Matrix = new Predator[26, 118];
            for (int roka_i = 0; roka_i < rokak; roka_i++)
            {
                SzuletettRokak += 1;
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
        public Predator[,] Nyomkovetes(Prey[,] prey_jatekter_logika_Matrix, Predator[,] regi_predator_jatekter_logika_Matrix)
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
                            int irany = r.Next(1,21);
                            if (regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota - lepes >= 0)
                            {
                                regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota = regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota - lepes;

                                regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota = regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota + (prey_jatekter_logika_Matrix[i, j].lenyAllapota + prey_jatekter_logika_Matrix[i, j].lenyKaja);
                                prey_jatekter_logika_Matrix[i, j] = null;

                                switch (irany){
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                        //ball
                                        regi_predator_jatekter_logika_Matrix[i, j-irany] = regi_predator_jatekter_logika_Matrix[i, j];
                                        regi_predator_jatekter_logika_Matrix[i, j] = null; 
                                        break;

                                    case 6:
                                    case 7:
                                    case 8:
                                    case 9:
                                    case 10:
                                        //fel
                                        regi_predator_jatekter_logika_Matrix[i - irany, j] = regi_predator_jatekter_logika_Matrix[i, j];
                                        regi_predator_jatekter_logika_Matrix[i, j] = null;
                                        break;

                                    case 11:
                                    case 12:
                                    case 13:
                                    case 14:
                                    case 15:
                                        //jobb
                                        regi_predator_jatekter_logika_Matrix[i, j + irany] = regi_predator_jatekter_logika_Matrix[i, j];
                                        regi_predator_jatekter_logika_Matrix[i, j] = null;
                                        break;

                                    case 16:
                                    case 17:
                                    case 18:
                                    case 19:
                                    case 20:
                                        //le
                                        regi_predator_jatekter_logika_Matrix[i + irany, j] = regi_predator_jatekter_logika_Matrix[i, j];
                                        regi_predator_jatekter_logika_Matrix[i, j] = null;
                                        break;
                                }
                            }
                            
                            else
                            {
                                if (regi_predator_jatekter_logika_Matrix[i, j].lenyKaja == 0 || regi_predator_jatekter_logika_Matrix[i, j].lenyKaja - (lepes - regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota) <= 0)
                                {
                                    LetezettRokak.Add(regi_predator_jatekter_logika_Matrix[i, j]);
                                    regi_predator_jatekter_logika_Matrix[i, j] = null;
                                }

                                else
                                {
                                    regi_predator_jatekter_logika_Matrix[i, j].lenyKaja = regi_predator_jatekter_logika_Matrix[i, j].lenyKaja - (lepes - regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota);

                                    regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota = (regi_predator_jatekter_logika_Matrix[i, j].lenyAllapota + (prey_jatekter_logika_Matrix[i, j].lenyAllapota + prey_jatekter_logika_Matrix[i, j].lenyKaja));
                                    prey_jatekter_logika_Matrix[i, j] = null;

                                    switch (irany)
                                    {
                                        case 1:
                                            //ball
                                            regi_predator_jatekter_logika_Matrix[i, j - irany] = regi_predator_jatekter_logika_Matrix[i, j];
                                            regi_predator_jatekter_logika_Matrix[i, j] = null;
                                            break;

                                        case 2:
                                            //fel
                                            regi_predator_jatekter_logika_Matrix[i - irany, j] = regi_predator_jatekter_logika_Matrix[i, j];
                                            regi_predator_jatekter_logika_Matrix[i, j] = null;
                                            break;

                                        case 3:
                                            //jobb
                                            regi_predator_jatekter_logika_Matrix[i, j + irany] = regi_predator_jatekter_logika_Matrix[i, j];
                                            regi_predator_jatekter_logika_Matrix[i, j] = null;
                                            break;

                                        case 4:
                                            //le
                                            regi_predator_jatekter_logika_Matrix[i + irany, j] = regi_predator_jatekter_logika_Matrix[i, j];
                                            regi_predator_jatekter_logika_Matrix[i, j] = null;
                                            break;
                                    }
                                }
                            }
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
            Prey[,]? prey_jatekter_logika_Matrix = new Prey[26, 118];
            for (int nyulak_i = 0; nyulak_i < nyulak; nyulak_i++)
            {
                SzuletettNyulak += 1;
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

        #region prey pathFinding
        public Prey[,] lepes(Food[,] repa_jatekter_logika_Matrix,Prey[,] regi_prey_jatekter_logika_Matrix)
        {
            for (int i = 0; i < regi_prey_jatekter_logika_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < regi_prey_jatekter_logika_Matrix.GetLength(1); j++)
                {
                    try
                    {
                        if (regi_prey_jatekter_logika_Matrix[i, j].Lenytipusa == "prey")
                        {
                            int lepes = r.Next(1, 4);
                            int irany = r.Next(1, 4);
                            
                            if (regi_prey_jatekter_logika_Matrix[i, j].lenyAllapota - lepes >= 0)
                            {

                                regi_prey_jatekter_logika_Matrix[i, j].lenyAllapota = (regi_prey_jatekter_logika_Matrix[i, j].lenyAllapota + repa_jatekter_logika_Matrix[i, j].lenyKaja) - lepes;
                                repa_jatekter_logika_Matrix[i, j].lenyKaja = 0;

                                MegevettRepakErteke += repa_jatekter_logika_Matrix[i, j].lenyKaja;
                                MegevettRepakSzama += 1;

                                switch (irany)
                                {
                                    case 1:
                                        //ball
                                        regi_prey_jatekter_logika_Matrix[i, j - irany] = regi_prey_jatekter_logika_Matrix[i, j];
                                        regi_prey_jatekter_logika_Matrix[i, j] = null;
                                        break;

                                    case 2:
                                        //fel
                                        regi_prey_jatekter_logika_Matrix[i - irany, j] = regi_prey_jatekter_logika_Matrix[i, j];
                                        regi_prey_jatekter_logika_Matrix[i, j] = null;
                                        break;

                                    case 3:
                                        //jobb
                                        regi_prey_jatekter_logika_Matrix[i, j + irany] = regi_prey_jatekter_logika_Matrix[i, j];
                                        regi_prey_jatekter_logika_Matrix[i, j] = null;
                                        break;

                                    case 4:
                                        //le
                                        regi_prey_jatekter_logika_Matrix[i + irany, j] = regi_prey_jatekter_logika_Matrix[i, j];
                                        regi_prey_jatekter_logika_Matrix[i, j] = null;
                                        break;
                                }
                            }

                            else
                            {
                                if (regi_prey_jatekter_logika_Matrix[i, j].lenyKaja == 0 || regi_prey_jatekter_logika_Matrix[i, j].lenyKaja - (lepes - regi_prey_jatekter_logika_Matrix[i, j].lenyAllapota) <= 0)
                                {
                                    LetezettNyulak.Add(regi_prey_jatekter_logika_Matrix[i, j]);
                                    regi_prey_jatekter_logika_Matrix[i, j] = null;
                                }

                                else {
                                    regi_prey_jatekter_logika_Matrix[i, j].lenyKaja = regi_prey_jatekter_logika_Matrix[i, j].lenyKaja - (lepes - regi_prey_jatekter_logika_Matrix[i, j].lenyAllapota);

                                    regi_prey_jatekter_logika_Matrix[i, j].lenyAllapota = (regi_prey_jatekter_logika_Matrix[i, j].lenyAllapota + repa_jatekter_logika_Matrix[i, j].lenyKaja);
                                    repa_jatekter_logika_Matrix[i, j].lenyKaja = 0;

                                    MegevettRepakErteke += repa_jatekter_logika_Matrix[i, j].lenyKaja;
                                    MegevettRepakSzama += 1;

                                    switch (irany)
                                    {
                                        case 1:
                                            //ball
                                            regi_prey_jatekter_logika_Matrix[i, j - irany] = regi_prey_jatekter_logika_Matrix[i, j];
                                            regi_prey_jatekter_logika_Matrix[i, j] = null;
                                            break;

                                        case 2:
                                            //fel
                                            regi_prey_jatekter_logika_Matrix[i - irany, j] = regi_prey_jatekter_logika_Matrix[i, j];
                                            regi_prey_jatekter_logika_Matrix[i, j] = null;
                                            break;

                                        case 3:
                                            //jobb
                                            regi_prey_jatekter_logika_Matrix[i, j + irany] = regi_prey_jatekter_logika_Matrix[i, j];
                                            regi_prey_jatekter_logika_Matrix[i, j] = null;
                                            break;

                                        case 4:
                                            //le
                                            regi_prey_jatekter_logika_Matrix[i + irany, j] = regi_prey_jatekter_logika_Matrix[i, j];
                                            regi_prey_jatekter_logika_Matrix[i, j] = null;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            return regi_prey_jatekter_logika_Matrix;
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