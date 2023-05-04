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
    public class VehiculeIntervention_SRV : IBase_SRV<VehiculeIntervention_DTO>
    {

        // champs

        protected IDepot_DAL<VehiculeIntervention_DAL> depot;
        public VehiculeIntervention_SRV(IDepot_DAL<VehiculeIntervention_DAL> dpt)
        {
            this.depot = dpt;
        }

        public VehiculeIntervention_SRV() : this(new VehiculeIntervention_Depot_DAL()) { }

        // methodes privées

        private VehiculeIntervention Get_VI_BLL_By_STO(VehiculeIntervention_DTO vi_DTO)
        {
            VehiculeIntervention_DAL vi_DAL = Get_VI_DAL_by_BTO(vi_DTO);

            if (vi_DAL == null)
                throw new Exception("Pas de vehiculeIntervention avec cet id");

            var vehiculeIntervention = new VehiculeIntervention(vi_DAL.IdIntervention, vi_DAL.IdVehiculeIntervention, vi_DAL.ImmatriculationVehicule)
            return vehiculeIntervention;
        }

        private VehiculeIntervention_DAL Get_VI_DAL_by_BTO(VehiculeIntervention_DTO vi)
        {
            if (vi.idIntervention == null)
                throw new Exception("L'id du vehiculeIntervention est null");

            var vi_DAL = new VehiculeIntervention_DAL(vi.IdVehiculeIntervention, vi.idIntervention, vi.immatriculationVehicule);

            return vi_DAL;
        }
        public void Ajouter(VehiculeIntervention_DTO o)
        {
            var vi_DAL = Get_VI_DAL_by_BTO(o);

            depot.Insert(vi_DAL);
        }

        public IEnumerable<VehiculeIntervention_DTO> GetAll()
        {
            var vi_DAL_List = depot.GetAll();

            var vi_DTO_List = new List<VehiculeIntervention_DTO> { };

            foreach (VehiculeIntervention_DAL vehiculeIntervention_DAL in vi_DAL_List)
            {
                var vi_DTO = new VehiculeIntervention_DTO()
                {
                   IdVehiculeIntervention = vehiculeIntervention_DAL.IdVehiculeIntervention,
                   idIntervention = vehiculeIntervention_DAL.IdIntervention,
                   immatriculationVehicule = vehiculeIntervention_DAL.ImmatriculationVehicule
                };

                vi_DTO_List.Add(vi_DTO);
            };

            return vi_DTO_List;

        }

        public VehiculeIntervention_DTO GetById(string id)
        {
            throw new NotImplementedException();
        }

        public VehiculeIntervention_DTO GetById(int id)
        {
            var vi_DAL = depot.GetById(id);
            if (vi_DAL == null) throw new Exception("Pas de vehiculeIntervention trouvé avec le code barre : " + id);
            var vi_DTO = new VehiculeIntervention_DTO()
            {
               IdVehiculeIntervention = vi_DAL.IdVehiculeIntervention,
               idIntervention= vi_DAL.IdIntervention,
               immatriculationVehicule = vi_DAL.ImmatriculationVehicule
            };

            return vi_DTO;
        }

        public void Modifier(VehiculeIntervention_DTO o)
        {
            var vi_DAL = Get_VI_DAL_by_BTO(o);

            depot.Update(vi_DAL);
        }

        public void Supprimer(string id)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(int id)
        {
            if (depot.GetById(id) == null) throw new Exception("Aucun vehiculeIntervention trouvé avec l'id : " + id);
            depot.Delete(id);
        }

    }
}
