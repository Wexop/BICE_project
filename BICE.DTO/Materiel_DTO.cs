using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DTO
{
    internal class Materiel_DTO
    {
        public string CodeBarre { get; set; }
        public string Nom { get; set; }
        public int Categorie_ID { get; set; }
        public int? Nb_utilisation { get; set; }
        public int? Nb_utilisation_max { get; set; }
        public DateTime? Date_peremption { get; set; }
        public DateTime? Date_controle { get; set; }
        public DateTime? Date_prochain_controle { get; set; }
        public bool Stock { get; set; }
    }
}
