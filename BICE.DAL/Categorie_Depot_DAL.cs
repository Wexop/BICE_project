using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Categorie_Depot_DAL : Depot_DAL<Categorie_DAL>
    {
        public override void Delete(int id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[Categories]
                                     WHERE categorie_id=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }

        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Categorie_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Categories]";


            var reader = Commande.ExecuteReader();

            var liste = new List<Categorie_DAL>();

            while (reader.Read()) //j'ai trouvé une ligne
            {
                var id = reader.GetInt32(0);

                liste.Add(new Categorie_DAL(id, //Id
                                    reader.GetString(1) // nom
                ));
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return liste;
        }

        public override Categorie_DAL GetById(int id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Categories]
                                     WHERE categorie_id=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            Categorie_DAL c = null;

            if (reader.Read()) //j'ai trouvé une ligne
            {

                c = new Categorie_DAL(id, //Id
                                    reader.GetString(1) // nom
                );
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return c;
        }

        public override Categorie_DAL GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override Categorie_DAL Insert(Categorie_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO [dbo].[Categories]
                                           (
                                           ,[nom])
                                         VALUES
                                           (@nom); select scope_identity()";

            Commande.Parameters.Add(new SqlParameter("@nom", p.Nom));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }

        public override Categorie_DAL Update(Categorie_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[Categories]
                                           set
                                           [nom]=@nom
                                     WHERE categorie_id=@categorie_id";

            Commande.Parameters.Add(new SqlParameter("@categorie_id", p.Id_categorie));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }
    }
}
