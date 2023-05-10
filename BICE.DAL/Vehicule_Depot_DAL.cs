using BICE.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Vehicule_Depot_DAL : Depot_DAL<Vehicule_DAL>
    {
        public override void Delete(string id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[Vehicules]
                                     WHERE immatriculation=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Vehicule_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Vehicules]";


            var reader = Commande.ExecuteReader();

            var liste = new List<Vehicule_DAL>();

            while (reader.Read()) //j'ai trouvé une ligne
            {
                var id = reader.GetString(0);

                liste.Add(new Vehicule_DAL(id, //Id
                                    reader.GetString(1), // nom
                                    reader.GetInt32(2), // numero
                                    reader.GetBoolean(3) // utilisable
                ));
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return liste;
        }

        public override Vehicule_DAL GetById(string id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Vehicules]
                                     WHERE immatriculation=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            Vehicule_DAL v = null;

            if (reader.Read()) //j'ai trouvé une ligne
            {

                v = new Vehicule_DAL(id, //Id
                                    reader.GetString(1), // nom
                                    reader.GetInt32(2), // numero
                                    reader.GetBoolean(3) // utilisable
                );
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return v;
        }

        public override Vehicule_DAL GetById(int id)
        {
            throw new NotImplementedException("Impossible avec un int en tant qu'id, seulement un string possible.");
        }

        public override Vehicule_DAL Insert(Vehicule_DAL v)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO [dbo].[Vehicules]
                                           ([immatriculation]
                                           ,[nom]
                                           ,[numero]
                                           ,[utilisable])
                                         VALUES
                                           (@immatriculation
                                           ,@nom
                                           ,@numero
                                           ,@utilisable); select scope_identity()";

            Commande.Parameters.Add(new SqlParameter("@immatriculation", v.Immatriculation));
            Commande.Parameters.Add(new SqlParameter("@nom", v.Nom));
            Commande.Parameters.Add(new SqlParameter("@numero", v.Numero));
            Commande.Parameters.Add(new SqlParameter("@utilisable", v.Utilisable));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return v;
        }

        public override Vehicule_DAL Update(Vehicule_DAL v)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[Vehicules]
                                           set
                                           [nom]=@nom
                                           ,[numero]=@numero
                                           ,[utilisable]=@utilisable
                                     WHERE immatriculation=@immatriculation";

            Commande.Parameters.Add(new SqlParameter("@immatriculation", v.Immatriculation));
            Commande.Parameters.Add(new SqlParameter("@nom", v.Nom));
            Commande.Parameters.Add(new SqlParameter("@numero", v.Numero));
            Commande.Parameters.Add(new SqlParameter("@utilisable", v.Utilisable));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return v;
        }
    }
}
