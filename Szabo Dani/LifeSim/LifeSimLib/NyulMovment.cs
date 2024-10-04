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

        static string[] iranyok = { "Fel", "Le", "Jobbra", "Balra" };  

        public int Nap { get; set; }

        public NyulMovment(int[,] matrix, int minGen)
        {
            Nap = 1;
            run = true;
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

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        
                        if (Nap != 0)
                        {
                            matrix[i, j]--;
                        }

                        int NewX, NewY;
                        bool validMove = false;

                        
                        do
                        {
                            
                            Move(iranyok[random.Next(0, 4)], i, j, out NewX, out NewY);

                            
                            if (NewX >= 0 && NewX < matrix.GetLength(0) && NewY >= 0 && NewY < matrix.GetLength(1))
                            {
                                if (NewX != lastX || NewY != lastY) 
                                {
                                    validMove = true;
                                }
                            }
                        } while (!validMove); 

                        
                        if (matrix[NewX, NewY] == 0)
                        {
                            int jelenlegiErtek = matrix[i, j];

                            
                            int szukseges = Math.Min(3 - jelenlegiErtek, fuvek[i, j]);

                            
                            matrix[NewX, NewY] = jelenlegiErtek + szukseges;

                            
                            fuvek[i, j] -= szukseges;

                            
                            matrix[i, j] = 0;

                            
                            lastX = i;
                            lastY = j;
                        }
                    }
                }
            }
            Nap++; 
        }



        static void Move(string irany, int oldX, int oldY, out int NewX, out int NewY)
        {
         
            NewX = oldX;
            NewY = oldY;

            
            if (irany == "Fel")
            {
                NewX = oldX - 1;  
            }
            else if (irany == "Le")
            {
                NewX = oldX + 1;  
            }
            else if (irany == "Jobbra")
            {
                NewY = oldY + 1;  
            }
            else if (irany == "Balra")
            {
                NewY = oldY - 1;  
            }
        }
    }
}
