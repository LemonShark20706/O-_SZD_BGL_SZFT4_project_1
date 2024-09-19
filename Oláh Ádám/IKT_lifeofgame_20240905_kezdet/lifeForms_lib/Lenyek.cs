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
            
            return predator_jatekter_logika_Matrix;
        }
        #endregion

        #region predator pathFinding
        #endregion

        #region prey helyzete
        public Prey[,] PreyLehelyezese(int nyulak)
        {
            Prey[,] prey_jatekter_logika_Matrix = new Prey[26, 118];
            
            return prey_jatekter_logika_Matrix;
        }
        #endregion

        #region food helyzete
        public Food[,] FoodLehelyezese()
        {
            Food[,] kaja_jatekter_logika_Matrix = new Food[26, 118];
            
            return kaja_jatekter_logika_Matrix;
        }
        #endregion

        #region
        #endregion
    }
}