using BICE.BLL;
using BICE.DAL;
using BICE.DTO;
using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public class Vehicule_SRV : IBase_SRV<Vehicule_DTO>
    {

        // champs

        protected IDepot_DAL<Vehicule_DAL> depot;
        public Vehicule_SRV(IDepot_DAL<Vehicule_DAL> dpt)
        {
            this.depot = dpt;
        }

        public Vehicule_SRV() : this(new Vehicule_Depot_DAL()) { }

        // methodes privées

        private Vehicule GetVehicule_BLLByDTO(Vehicule_DTO vehicule)
        {
            Vehicule_DAL vehicule_DAL = GetVehicule_DALByMateriel_DTO(vehicule);

            if (vehicule_DAL == null)
                throw new Exception("Pas de vehicule avec cet id");

            Vehicule vehicule_BLL = new Vehicule(vehicule_DAL.Immatriculation, vehicule_DAL.Nom, vehicule_DAL.Numero, vehicule_DAL.Utilisable);

            return vehicule_BLL;
        }

        private Vehicule_DAL GetVehicule_DALByMateriel_DTO(Vehicule_DTO vehicule)
        {
            if (vehicule.Immatriculation == null)
                throw new Exception("L'id du vehicule est null");

            var vehicule_DAL = new Vehicule_DAL(vehicule.Immatriculation, vehicule.Nom, vehicule.Numero, vehicule.Utilisable);
            return vehicule_DAL;
        }
        public void Ajouter(Vehicule_DTO v)
        {
            var vehiculeDAL = GetVehicule_DALByMateriel_DTO(v);

            depot.Insert(vehiculeDAL);
        }

        public IEnumerable<Vehicule_DTO> GetAll()
        {
            var vehicule_DAL_List = depot.GetAll();

            var vehicule_DTO_List = new List<Vehicule_DTO> { };

            foreach (Vehicule_DAL vehicule_DAL in vehicule_DAL_List)
            {
                var vehicule_DTO = new Vehicule_DTO()
                {
                    Immatriculation = vehicule_DAL.Immatriculation,
                    Nom = vehicule_DAL.Nom,
                    Utilisable = vehicule_DAL.Utilisable,
                    Numero = vehicule_DAL.Numero
                };

                vehicule_DTO_List.Add(vehicule_DTO);
            };

            return vehicule_DTO_List;
        }

        public Vehicule_DTO GetById(string id)
        {
            var vehicule_DAL = depot.GetById(id);

            if (vehicule_DAL == null) throw new Exception("Pas de voiture avec cet id ");

            var vehiculeDTO = new Vehicule_DTO()
            {
                Immatriculation = vehicule_DAL.Immatriculation,
                Nom = vehicule_DAL.Nom,
                Numero = vehicule_DAL.Numero,
                Utilisable = vehicule_DAL.Utilisable
            };

            return vehiculeDTO;
        }

        public void Modifier(Vehicule_DTO o)
        {

            var vehiculeDAL = GetVehicule_DALByMateriel_DTO(o);

            depot.Update(vehiculeDAL);
        }

        public void Supprimer(string id)
        {
            if (depot.GetById(id) == null) throw new Exception("Aucun vehicule trouvé avec l'id : " + id);
            depot.Delete(id);
        }

        public Vehicule_DTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
