using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifeForms_lib
{
    public class Predator
    {
        #region lény képe
        public string lenyKepe = "🦊";
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
        public Predator()
        {
            Lenytipusa = "predator";
            this.lenyKaja = 5;
            this.lenyEletTartama = 0;
            this.lenyAllapota = 7;
        }
        #endregion

        #region
        #endregion
    }
}