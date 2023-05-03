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
    public class Categorie_SRV : IBase_SRV<Categorie_DTO>
    {

        // champs

        protected IDepot_DAL<Categorie_DAL> depot;
        public Categorie_SRV(IDepot_DAL<Categorie_DAL> dpt)
        {
            this.depot = dpt;
        }

        public Categorie_SRV() : this(new Categorie_Depot_DAL()) { }

        // methodes privées

        private Categorie GetCategorie_BLLByDTO(Categorie_DTO categorie)
        {
            Categorie_DAL categorie_DAL = GetCategorie_DALByMateriel_DTO(categorie);

            if (categorie == null)
                throw new Exception("Pas de catégorie avec cet id");

            Categorie categorie_BLL = new Categorie(categorie_DAL.Id_categorie, categorie_DAL.Nom);

            return categorie_BLL;
        }

        private Categorie_DAL GetCategorie_DALByMateriel_DTO(Categorie_DTO categorie)
        {
            var categorie_DAL = new Categorie_DAL(categorie.Id_categorie, categorie.Nom);
            return categorie_DAL;
        }
        public void Ajouter(Categorie_DTO o)
        {
            var categorie = GetCategorie_DALByMateriel_DTO(o);

            depot.Insert(categorie);
        }

        public IEnumerable<Categorie_DTO> GetAll()
        {
            var categorie_DAL_List = depot.GetAll();

            var categorie_DTO_List = new List<Categorie_DTO> { };

            foreach (Categorie_DAL categorie_DAL in categorie_DAL_List)
            {
                var categorie_DTO = new Categorie_DTO()
                {
                    Id_categorie = categorie_DAL.Id_categorie,
                    Nom= categorie_DAL.Nom,
                };

                categorie_DTO_List.Add(categorie_DTO);
            };

            return categorie_DTO_List;
        }

        public Categorie_DTO GetById(string id)
        {
            var categorie_DAL = depot.GetById(id);
            if (categorie_DAL == null) throw new Exception("Pas de catégorie trouvé avec le code barre : " + id);
            var categorie_DTO = new Categorie_DTO()
            {
                Id_categorie = categorie_DAL.Id_categorie,
                Nom = categorie_DAL.Nom,
            };

            return categorie_DTO;
        }

        public Categorie_DTO GetById(int id)
        {
            var categorie_DAL = depot.GetById(id);
            if (categorie_DAL == null) throw new Exception("Pas de catégorie trouvé avec le code barre : " + id);
            var categorie_DTO = new Categorie_DTO()
            {
                Id_categorie = categorie_DAL.Id_categorie,
                Nom = categorie_DAL.Nom,
            };

            return categorie_DTO;
        }

        public void Modifier(Categorie_DTO o)
        {
            var categorie = GetCategorie_DALByMateriel_DTO(o);

            depot.Update(categorie);
        }

        public void Supprimer(string id)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(int id)
        {
            if (depot.GetById(id) == null) throw new Exception("Aucune categorie trouvé avec l'id : " + id);
            depot.Delete(id);
        }
    }
}
