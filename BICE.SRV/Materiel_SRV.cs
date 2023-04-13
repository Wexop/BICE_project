using BICE.DTO;
using BICE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometrie.DAL;

namespace BICE.SRV
{
    internal class Materiel_SRV<T> : IMateriel_SRV<T>
        where T : Materiel_DTO
    {
        // champs

        protected IDepot_DAL<Materiel_DAL> depot;
        public Materiel_SRV(IDepot_DAL<Materiel_DAL> dpt)
        {
            this.depot = dpt;
        }

        public Materiel_SRV() : this(new Materiel_Depot_DAL()) { }

        // methodes privées

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public T Modifier(T m)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(Materiel_DTO m)
        {
            throw new NotImplementedException();
        }

        public T Ajouter(T m)
        {
            throw new NotImplementedException();
        }
    }
}
