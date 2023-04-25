namespace BICE.BLL
{
    public class Materiel
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

        // constructeur
        public Materiel(string codeBarre, string nom, int categorieId, int? nbUtilisation, int? nbUtilisationMax, DateTime? datePeremption, DateTime? dateControle, DateTime? dateProchainControle, bool stock)
        {
            CodeBarre = codeBarre;
            Nom = nom;
            Categorie_ID = categorieId;
            Nb_utilisation = nbUtilisation;
            Nb_utilisation_max = nbUtilisationMax;
            Date_peremption = datePeremption;
            Date_controle = dateControle;
            Date_prochain_controle = dateProchainControle;
            Stock = stock;
        }


    }
}