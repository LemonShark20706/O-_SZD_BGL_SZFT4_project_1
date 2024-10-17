using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifeForms_lib
{
    public class Prey
    {
        Random r = new Random();
        
        #region lény képe
        public string lenyKepe = "🐰";
        #endregion

        #region lény tipusa
        private string lenytipusa;

        public string Lenytipusa
        {
            get { return lenytipusa; }
            set { lenytipusa = value; }
        }
        #endregion

        #region lény kaja
        public int lenyKaja { get; set; }
        #endregion

        #region kor mit túl élt
        public int lenyEletTartama { get; set; }
        #endregion

        #region állapot
        public int lenyAllapota { get; set; }
        #endregion

        #region Konstruktor
        public Prey()
        {
            Lenytipusa = "prey";
            this.lenyKaja = 3;
            this.lenyEletTartama = 0;
            this.lenyAllapota = 5;
        }
        #endregion

        #region
        #endregion
    }
}
