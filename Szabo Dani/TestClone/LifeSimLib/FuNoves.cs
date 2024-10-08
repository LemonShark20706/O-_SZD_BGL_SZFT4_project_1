using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimLib
{
    public class FuNoves
    {
        public int MaxGrow {  get; set; }
        Random random = new Random();

        

        public FuNoves(int[,] matrix,int gyakorisag)
        {
            bool run = true;
            while (run)
            {
                int i;
                int j;
                for (int k = 0; k < gyakorisag; k++)
                {
                    i = random.Next(1, matrix.GetLength(0));
                    j = random.Next(1, matrix.GetLength(1));
                    if (matrix[i, j] < 3)
                    {
                        matrix[i, j] += 1;
                        run = false;
                    }
                }
            }


        }
        public FuNoves(int grow, int[,]matrix,int def)
        {
            MaxGrow = grow;
            
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    matrix[i, j] = def;
                }
            }
        }
    }
}
