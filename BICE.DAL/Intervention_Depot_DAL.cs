using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Intervention_Depot_DAL : Depot_DAL<Intervention_DAL>
    {
        public override void Delete(int id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[Interventions]
                                     WHERE id_intervention=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }

        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Intervention_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Interventions]";


            var reader = Commande.ExecuteReader();

            var liste = new List<Intervention_DAL>();

            while (reader.Read()) //j'ai trouvé une ligne
            {
                var id = reader.GetInt32(0);

                liste.Add(new Intervention_DAL(id, //Id
                                    reader.GetDateTime(1) // date
                ));
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return liste;
        }

        public override Intervention_DAL GetById(int id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Interventions]
                                     WHERE id_intervention=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            Intervention_DAL i = null;

            if (reader.Read()) //j'ai trouvé une ligne
            {

                i = new Intervention_DAL(id, //Id
                                    reader.GetDateTime(1) // date
                );
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return i;
        }

        public override Intervention_DAL GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override Intervention_DAL Insert(Intervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO [dbo].[Interventions]
                                           ([id_intervention]
                                           ,[date])
                                         VALUES
                                           (@id_intervention
                                           ,@date); select scope_identity()";

            Commande.Parameters.Add(new SqlParameter("@id_intervention", p.Id_intervention));
            Commande.Parameters.Add(new SqlParameter("@date", p.Date_intervention));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }

        public override Intervention_DAL Update(Intervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[Interventions]
                                           set
                                           [id_intervention]=@id_intervention
                                           ,[date]=@date
                                     WHERE id_intervention=@id_intervention";

            Commande.Parameters.Add(new SqlParameter("@id_intervention", p.Id_intervention));
            Commande.Parameters.Add(new SqlParameter("@date", p.Date_intervention));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }
    }
}
