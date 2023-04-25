using BICE.DTO;
using BICE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometrie.DAL;
using System.Drawing;
using BICE.BLL;

namespace BICE.SRV
{
    public class Materiel_SRV : IMateriel_SRV<Materiel_DTO>
    {
        // champs

        protected IDepot_DAL<Materiel_DAL> depot;
        public Materiel_SRV(IDepot_DAL<Materiel_DAL> dpt)
        {
            this.depot = dpt;
        }

        public Materiel_SRV() : this(new Materiel_Depot_DAL()) { }

        // methodes privées

        private Materiel GetMateriel_BLLByDTO(Materiel_DTO materiel)
        {
            Materiel_DAL materiel_DAL = GetMateriel_DALByMateriel_DTO(materiel);

            if (materiel_DAL == null)
                throw new Exception("Pas de forme avec cet id");

            Materiel materiel_BLL = new Materiel(materiel_DAL.CodeBarre, materiel_DAL.Nom, materiel_DAL.Categorie_ID, materiel_DAL.Nb_utilisation, materiel_DAL.Nb_utilisation_max, materiel_DAL.Date_peremption, materiel_DAL.Date_controle, materiel_DAL.Date_prochain_controle, materiel_DAL.Stock);

            return materiel_BLL;
        }

        private Materiel_DAL GetMateriel_DALByMateriel_DTO(Materiel_DTO materiel)
        {
            if (materiel.CodeBarre == null)
                throw new Exception("L'id de la forme est null");

            var materiel_DAL = depot.GetById(materiel.CodeBarre);
            return materiel_DAL;
        }

        Materiel_DTO IMateriel_SRV<Materiel_DTO>.GetById(string id)
        {
            var materiel_DAL = depot.GetById(id);
            if (materiel_DAL == null) throw new Exception("Pas de materiel trouvé avec le code barre" + id);
            var materiel_DTO = new Materiel_DTO()
            {
                CodeBarre = materiel_DAL.CodeBarre,
                Categorie_ID = materiel_DAL.Categorie_ID,
                Nb_utilisation = materiel_DAL.Nb_utilisation,
                Nb_utilisation_max = materiel_DAL.Nb_utilisation_max,
                Date_controle = materiel_DAL.Date_controle,
                Date_peremption = materiel_DAL.Date_peremption,
                Date_prochain_controle = materiel_DAL.Date_prochain_controle,
                Stock = materiel_DAL.Stock
            };

            return materiel_DTO;
        }

        IEnumerable<Materiel_DTO> IMateriel_SRV<Materiel_DTO>.GetAll()
        {
            throw new NotImplementedException();
        }

        public Materiel_DTO Ajouter(Materiel_DTO m)
        {
            throw new NotImplementedException();
        }

        public Materiel_DTO Modifier(Materiel_DTO m)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(Materiel_DTO m)
        {
            throw new NotImplementedException();
        }
    }
}
