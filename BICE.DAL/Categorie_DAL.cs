using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    internal class Categorie_DAL
    {
        public int Id_categorie { get; set; }
        public string Nom { get; set; }

        public Categorie_DAL(int id_categorie, string nom) 
            => (Id_categorie, Nom) = (id_categorie, nom); 
    }
}
