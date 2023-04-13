using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Materiel_DAL
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

        public Materiel_DAL(string codeBarre, string nom, int categorie_ID, bool stock)
            => (CodeBarre, Nom, Categorie_ID, Stock) = (codeBarre, nom, categorie_ID, stock);

        public Materiel_DAL(string codeBarre, string nom, int categorie_ID, int nbUtilisation, int nbUtilisationMax, bool stock)
            : this(codeBarre, nom, categorie_ID, stock) => (Nb_utilisation, Nb_utilisation_max) = (nbUtilisation, nbUtilisationMax);

        public Materiel_DAL(string codeBarre, string nom, int categorie_ID, DateTime datePeremption, bool stock)
            : this(codeBarre, nom, categorie_ID, stock) => (Date_peremption) = (datePeremption);

        public Materiel_DAL(string codeBarre, string nom, int categorie_ID, DateTime dateControle, DateTime dateProchainControle, bool stock)
         : this(codeBarre, nom, categorie_ID, stock) => (Date_controle, Date_prochain_controle) = (dateControle, dateProchainControle);

        public Materiel_DAL(string codeBarre, string nom, int categorie_ID, int? nbUtilisation, int? nbUtilisationMax, DateTime? datePeremption, DateTime? dateControle, DateTime? dateProchainControle, bool stock)
        : this(codeBarre, nom, categorie_ID, stock) => (Nb_utilisation, Nb_utilisation_max, Date_peremption, Date_controle, Date_prochain_controle) = (nbUtilisation, nbUtilisationMax, datePeremption, dateControle, dateProchainControle);

    }
}
