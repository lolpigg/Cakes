using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cakes
{
    internal class Tort
    {
        public int PriceForma;
        public int PriceRazmer;
        public int PriceVkus;
        public int PriceKolichestvo;
        public int PriceGlazur;
        public int PriceDekor;

        public string NameForma;
        public string NameRazmer;
        public string NameVkus;
        public string NameKolichestvo;
        public string NameGlazur;
        public string NameDekor;
        public static List<Tort> FinalTort = new List<Tort>();
        public int Summing() => this.PriceDekor+this.PriceVkus+this.PriceGlazur+this.PriceForma+this.PriceRazmer;

       
        public Tort(int price = 0, string Fname = "",
            string Rname = "", string Vname = "", string Kname = "",
            string Gname = "", string Dname = "")
        {
            this.PriceForma = price;
            this.NameForma = Fname;
            this.NameRazmer = Rname;
            this.NameVkus = Vname;
            this.NameKolichestvo = Kname;
            this.NameGlazur = Gname;
            this.NameDekor = Dname;
        }
    }
}
