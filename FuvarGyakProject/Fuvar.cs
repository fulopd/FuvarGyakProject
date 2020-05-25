using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuvarGyakProject
{
    class Fuvar
    {
        //taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja
        //5240;2016-12-15 23:45:00;900;2,5;10,75;2,45;bankkártya
        public int taxi_id { get; set; }
        public DateTime indulas { get; set; }
        public double idotartam { get; set; }
        public double tavolsag { get; set; }
        public double viteldij { get; set; }
        public double borravalo { get; set; }
        public string fizetes_modja { get; set; }

        public Fuvar(int taxi_id, DateTime indulas, double idotartam, double tavolsag, double viteldij, double borravalo, string fizetes_modja)
        {
            this.taxi_id = taxi_id;
            this.indulas = indulas;
            this.idotartam = idotartam;
            this.tavolsag = tavolsag;
            this.viteldij = viteldij;
            this.borravalo = borravalo;
            this.fizetes_modja = fizetes_modja;
        }

    }
}
