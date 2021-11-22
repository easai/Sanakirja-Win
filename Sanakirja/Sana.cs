using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanakirja
{
    class Sana
    {
        public string En { get; set; }
        public string Fi { get; set; }

        public Sana() { }

        public Sana(string fi, string en)
        {
            Fi = fi;
            En = en;
        }

    }
}
