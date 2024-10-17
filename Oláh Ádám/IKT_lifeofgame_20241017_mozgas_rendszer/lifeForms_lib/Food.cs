using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifeForms_lib
{
    public class Food
    {
        #region lény képe
        public string lenyKepe = "🥕";
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

        #region Konstruktor
        public Food()
        {
            Lenytipusa = "food";
            this.lenyKaja = 1;
            this.lenyEletTartama = 0;
        }
        #endregion

        #region
        #endregion
    }
}
