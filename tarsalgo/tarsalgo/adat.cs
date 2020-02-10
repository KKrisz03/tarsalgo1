using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsalgo
{
    class adat
    {
        public adat(int ora, int perc, int id, bool bennt)
        {
            this.ora = ora;
            this.perc = perc;
            this.id = id;
            this.bennt = bennt;
        }

        public int ora { get; set; }
        public int perc { get; set; }
        public int id { get; set; }
        public bool bennt { get; set; }
    }
}
