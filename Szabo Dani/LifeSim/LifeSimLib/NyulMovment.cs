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
        int[,] NyulMatrix {  get; set; }
        public NyulMovment(int[,] matrix)
        {
            NyulMatrix = matrix;
        }
        public void NyulPlace()
        {
            bool run = true;
            while (run)
            {
                int i = random.Next(1, NyulMatrix.GetLength(0) - 1);
                int j = random.Next(1, NyulMatrix.GetLength(1) - 1);

                if (NyulMatrix[i, j] == 0)
                {
                    NyulMatrix[i, j] = 1;
                    run = false;
                }
            }
        }
    }
}
