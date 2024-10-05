using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimLib
{
    public class NyulMovment
    {
        Random random = new Random();
        private bool run { get; init; }

        public int Nap { get; private set; }
        public int MaxNyulErtek { get; init; }

        #region Kiertekeles
        public int OsszSzuletettNyul { get; private set; } 
        public int OsszHaltNyul { get; private set; } 
        public int OsszNyul(int[,] matrix) => matrix.Cast<int>().Where(x => x > 0).Count();
        #endregion

        public NyulMovment(int[,] matrix, int minGen, int maxNyulErtek)
        {
            Nap = 1;
            run = true;
            MaxNyulErtek = maxNyulErtek;

            for (int cik = 0; cik < minGen; cik++)
            {
                run = true;
                int i;
                int j;
                while (run)
                {
                    i = random.Next(0, matrix.GetLength(0));
                    j = random.Next(0, matrix.GetLength(1));
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = 1; 
                        run = false;
                    }
                }
            }
        }

        public void Lepes(int[,] matrix, int[,] fuvek)
        {
            int lastX = -1;
            int lastY = -1;
            bool szaporodott = false;  

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) 
                    {
                        if (Nap != 0)
                        {
                            if (matrix[i, j] - 1 == 0)
                            {
                                OsszHaltNyul++; // Halott nyúl hozzáadása
                                matrix[i, j] = 0;
                            }
                            else
                            {
                                matrix[i, j]--; 
                            }
                        }

                        int newX = i, newY = j;

                        if (!szaporodott && EllenorizSzomszedok(i, j, matrix))
                        {
                            szaporodott = true;  
                            EllenorizSzaporodas(i, j, matrix);
                            OsszSzuletettNyul++; // Született nyúl hozzáadása
                        }

                        (newX, newY) = KivalasztLegjobbLepes(i, j, matrix, fuvek, lastX, lastY);

                        if (matrix[newX, newY] == 0) 
                        {
                            int jelenlegiErtek = matrix[i, j];
                            int szukseges = Math.Min(MaxNyulErtek - jelenlegiErtek, fuvek[newX, newY]);
                            matrix[newX, newY] = jelenlegiErtek + szukseges;
                            fuvek[newX, newY] -= szukseges;

                            lastX = newX; 
                            lastY = newY;
                        }
                    }
                }
            }
            Nap++;
        }

        private bool EllenorizSzomszedok(int x, int y, int[,] matrix)
        {
            int[,] iranyok = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            for (int d = 0; d < iranyok.GetLength(0); d++)
            {
                int ujX = x + iranyok[d, 0];
                int ujY = y + iranyok[d, 1];

                if (ujX >= 0 && ujX < matrix.GetLength(0) && ujY >= 0 && ujY < matrix.GetLength(1))
                {
                    if (matrix[ujX, ujY] > 0) 
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void EllenorizSzaporodas(int x, int y, int[,] matrix)
        {
            int[,] iranyok = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
            List<(int, int)> uresMezok = new List<(int, int)>();

            for (int d = 0; d < iranyok.GetLength(0); d++)
            {
                int ujX = x + iranyok[d, 0];
                int ujY = y + iranyok[d, 1];

                if (ujX >= 0 && ujX < matrix.GetLength(0) && ujY >= 0 && ujY < matrix.GetLength(1))
                {
                    if (matrix[ujX, ujY] == 0) 
                    {
                        uresMezok.Add((ujX, ujY));
                    }
                }
            }

            if (uresMezok.Count > 0)
            {
                var veletlenUresMezo = uresMezok[random.Next(uresMezok.Count)];
                matrix[veletlenUresMezo.Item1, veletlenUresMezo.Item2] = 1; 
            }
        }

        private (int, int) KivalasztLegjobbLepes(int x, int y, int[,] matrix, int[,] fuvek, int lastX, int lastY)
        {
            int legjobbX = x, legjobbY = y;
            int maxFu = -1;

            int[,] iranyok = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            for (int d = 0; d < iranyok.GetLength(0); d++)
            {
                int ujX = x + iranyok[d, 0];
                int ujY = y + iranyok[d, 1];

                if (ujX >= 0 && ujX < matrix.GetLength(0) && ujY >= 0 && ujY < matrix.GetLength(1))
                {
                    if (fuvek[ujX, ujY] > maxFu && (ujX != lastX || ujY != lastY))
                    {
                        legjobbX = ujX;
                        legjobbY = ujY;
                        maxFu = fuvek[ujX, ujY];
                    }
                }
            }

            return (legjobbX, legjobbY);
        }
    }
}
