using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.BLL
{
    public class Categorie
    {
        public int Id_categorie { get; private set; }
        public string Nom { get; private set; }

        public Categorie(int id, string nom) 
        { 
            Id_categorie= id;
            Nom = nom;
        }
    }
}
