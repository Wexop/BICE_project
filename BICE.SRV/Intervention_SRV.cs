using BICE.BLL;
using BICE.DAL;
using BICE.DTO;
using BICE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV
{
    public class Intervention_SRV : IBase_SRV<Intervention_DTO>
    {

        // champs

        protected IDepot_DAL<Intervention_DAL> depot;
        public Intervention_SRV(IDepot_DAL<Intervention_DAL> dpt)
        {
            this.depot = dpt;
        }

        public Intervention_SRV() : this(new Intervention_Depot_DAL()) { }

        // methodes privées

        private Intervention GetMateriel_BLLByDTO(Intervention_DTO intervention)
        {
            Intervention_DAL intervention_DAL = GetMateriel_DALByMateriel_DTO(intervention);

            if (intervention_DAL == null)
                throw new Exception("Pas d'intervention avec cet id");

            Intervention intervention_BLL = new Intervention(intervention_DAL.Id_intervention, intervention_DAL.Date_intervention);
            return intervention_BLL;
        }

        private Intervention_DAL GetMateriel_DALByMateriel_DTO(Intervention_DTO intervention)
        {
            if (intervention.Id_intervention == null)
                throw new Exception("L'id de l'intervention est null");

            var intervention_DAL = new Intervention_DAL(intervention.Id_intervention, intervention.Date_intervention);

            return intervention_DAL;
        }

        public void Ajouter(Intervention_DTO o)
        {
            var intervention_DAL = GetMateriel_DALByMateriel_DTO(o);

            depot.Insert(intervention_DAL);

        }

        public IEnumerable<Intervention_DTO> GetAll()
        {
            var intervention_DAL_List = depot.GetAll();

            var intervention_DTO_List = new List<Intervention_DTO> { };

            foreach (Intervention_DAL intervention_DAL in intervention_DAL_List)
            {
                var intervention_DTO = new Intervention_DTO()
                {
                   Id_intervention = intervention_DAL.Id_intervention,
                   Date_intervention = intervention_DAL.Date_intervention
                };

                intervention_DTO_List.Add(intervention_DTO);
            };

            return intervention_DTO_List;
        }

        public Intervention_DTO GetById(int id)
        {
            var intervention_DAL = depot.GetById(id);
            if (intervention_DAL == null) throw new Exception("Pas d'intervention trouvé avec l'id : " + id);
            var intervention_DTO = new Intervention_DTO()
            {
                Id_intervention = intervention_DAL.Id_intervention,
                Date_intervention = intervention_DAL.Date_intervention
            };

            return intervention_DTO;
        }

        public Intervention_DTO GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Modifier(Intervention_DTO o)
        {
            var intervention_DAL = GetMateriel_DALByMateriel_DTO(o);

            depot.Update(intervention_DAL);
        }

        public void Supprimer(string id)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(int id)
        {
            if (depot.GetById(id) == null) throw new Exception("Aucune intervention trouvé avec l'id : " + id);
            depot.Delete(id);
        }
    }
}
