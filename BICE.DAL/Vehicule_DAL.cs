namespace BICE.DAL
{
    public class Vehicule_DAL
    {
        public string Immatriculation { get; set; }
        public string Nom { get; set; }
        public int Numero { get; set; }
        public bool Utilisable { get; set; }

        public Vehicule_DAL(string immatriculation, string nom, int numero, bool utilisable) 
            => (Immatriculation, Nom, Numero, Utilisable) = (immatriculation, nom, numero, utilisable);
    }
}