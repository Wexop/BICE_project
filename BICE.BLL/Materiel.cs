namespace BICE.BLL
{
    public class Materiel
    {
        public string CodeBarre { get; private set; }
        public string Nom { get; private set; }
        public int Categorie_ID { get; private set; }
        public int? Nb_utilisation { get; private set; }
        public int? Nb_utilisation_max { get; private set; }
        public DateTime? Date_peremption { get; private set; }
        public DateTime? Date_controle { get; private set; }
        public DateTime? Date_prochain_controle { get; private set; }
        public bool Stock { get; private set; }
        public string? Vehicule_ID { get; private set; }

        // constructeur
        public Materiel(string codeBarre, string nom, int categorieId, int? nbUtilisation, int? nbUtilisationMax, DateTime? datePeremption, DateTime? dateControle, DateTime? dateProchainControle, bool stock, string? vehicule_id)
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
            Vehicule_ID= vehicule_id;
        }

        public void RetourIntervention()
        {
            Nb_utilisation += 1;

            if (Nb_utilisation >= Nb_utilisation_max || DateTime.Now >= Date_peremption) Stock = false;
        }

    }
}