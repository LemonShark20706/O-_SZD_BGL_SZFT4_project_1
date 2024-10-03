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


        public FuNoves(int x,int y, int[,] matrix)
        {
            if(random.Next(0,50) == 0)
            {
                if (matrix[x,y] < 3)
                {
                    matrix[x, y] += 1;
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
