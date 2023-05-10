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
    public class MaterielIntervention_SRV : IMaterielIntervention_SRV<MaterielIntervention_DTO>
    {

        // champs

        protected IMaterielIntervention_Depot_DAL<MaterielIntervention_DAL> depot;
        public MaterielIntervention_SRV(IMaterielIntervention_Depot_DAL<MaterielIntervention_DAL> dpt)
        {
            this.depot = dpt;
        }

        public MaterielIntervention_SRV() : this(new MaterielIntervention_Depot_DAL()) { }

        // methodes privées

        private MaterielIntervention GetMaterielInterventionBLLByDTO(MaterielIntervention_DTO materielIntervention)
        {
            MaterielIntervention_DAL materielInterventionDAL = GetMaterielIntervention_DALByMaterielIntervention_DTO(materielIntervention);

            if (materielInterventionDAL == null)
                throw new Exception("Pas de materielIntervention avec cet id");

            MaterielIntervention materielInterventionBLL = new MaterielIntervention(materielInterventionDAL.IdVehiculeIntervention, materielInterventionDAL.CodeBarreMateriel);
            return materielInterventionBLL;
        }

        private MaterielIntervention_DAL GetMaterielIntervention_DALByMaterielIntervention_DTO(MaterielIntervention_DTO materielIntervention)
        {
            if (materielIntervention.IdVehiculeIntervention == null)
                throw new Exception("Le materielIntervention est null");

            var materielInterventionDAL = new MaterielIntervention_DAL(materielIntervention.IdVehiculeIntervention, materielIntervention.CodeBarreMateriel);
            return materielInterventionDAL;
        }

        public void Ajouter(MaterielIntervention_DTO o)
        {
            var MI_DAL = GetMaterielIntervention_DALByMaterielIntervention_DTO(o);

            depot.Insert( MI_DAL );
        }

        public IEnumerable<MaterielIntervention_DTO> GetAll()
        {
            var MI_DAL_LIST = depot.GetAll();

            var MI_DTO_LIST = new List<MaterielIntervention_DTO> { };

            foreach (MaterielIntervention_DAL materielIntervention_DAL in MI_DAL_LIST)
            {
                var materielIntervention_DTO = new MaterielIntervention_DTO()
                {
                  IdVehiculeIntervention = materielIntervention_DAL.IdVehiculeIntervention,
                  CodeBarreMateriel = materielIntervention_DAL.CodeBarreMateriel
                };

                MI_DTO_LIST.Add(materielIntervention_DTO);
            };

            return MI_DTO_LIST;
        }

        public MaterielIntervention_DTO GetById(string id)
        {
            throw new NotImplementedException();
        }

        public MaterielIntervention_DTO GetById(int idVehiculeIntervention, string codeBarre)
        {

            var MI_DAL = depot.GetById(idVehiculeIntervention, codeBarre);
            if (MI_DAL == null) throw new Exception("Pas de materielIntervention trouvé ");
            var MI_DTO = new MaterielIntervention_DTO()
            {
                IdVehiculeIntervention= MI_DAL.IdVehiculeIntervention,
                CodeBarreMateriel= MI_DAL.CodeBarreMateriel,
            };


            return MI_DTO;
        }

        public void Modifier(MaterielIntervention_DTO o)
        {
            var MI_DAL = GetMaterielIntervention_DALByMaterielIntervention_DTO(o);

            depot.Update(MI_DAL);
        }

        public void Supprimer(string id)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(int idVehiculeIntervention, string codeBarre)
        {
            if (depot.GetById(idVehiculeIntervention, codeBarre) == null) throw new Exception("Aucun materielIntervention trouvé ");
            depot.Delete(idVehiculeIntervention, codeBarre);
        }

        public MaterielIntervention_DTO GetById(int id)

        {
            throw new NotImplementedException();
        }

        public void Supprimer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
