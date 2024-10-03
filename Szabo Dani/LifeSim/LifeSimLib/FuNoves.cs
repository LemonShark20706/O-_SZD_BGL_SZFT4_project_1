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

        

        public FuNoves(int[,] matrix)
        {
            bool run = true;
            while (run)
            {


                int i = random.Next(1, matrix.GetLength(0) - 1);
                int j = random.Next(1, matrix.GetLength(1) - 1);
                if (matrix[i, j] < 3)
                {
                    matrix[i, j] += 1;
                    run = false;
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
