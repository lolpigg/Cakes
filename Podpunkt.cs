using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    public class Podpunkt
    {
        public int price;
        public string name;
        public string type;
        public Podpunkt()
        {
        }
        public Podpunkt(int price, string name, string type)
        {
            this.price = price;
            this.name = name;
            this.type = type;
        }
    }
}
