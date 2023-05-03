using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.BLL
{
    internal class Vehicule
    {
        public string Immatriculation { get; private set; }
        public string Nom { get; private set; }
        public int Numero { get; private set; }
        public bool Utilisable { get; private set; }

        public Vehicule(string immatriculation, string nom, int numero, bool utilisable)
        {
            Immatriculation = immatriculation;
            Nom = nom;
            Numero = numero;
            Utilisable = utilisable;
        }
    }
}
