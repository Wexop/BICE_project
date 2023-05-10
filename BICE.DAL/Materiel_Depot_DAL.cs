using BICE.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Materiel_Depot_DAL : Depot_DAL<Materiel_DAL>
    {
        public override void Delete(string id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[Materiels]
                                     WHERE code_barre=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Materiel_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Materiels]";


            var reader = Commande.ExecuteReader();

            var liste = new List<Materiel_DAL>();

            while (reader.Read()) //j'ai trouvé une ligne
            {
                var id = reader.GetString(0);

                liste.Add(new Materiel_DAL(id, //Id
                                    reader.GetString(1), // nom
                                    reader.GetInt32(2), // categorieID
                                    reader.GetSqlInt32(3).IsNull ? null : reader.GetInt32(3),  // nb_utilisation
                                    reader.GetSqlInt32(4).IsNull ? null : reader.GetInt32(4),  // nb_utilisation MAX
                                    reader.IsDBNull(5) ? null : reader.GetDateTime(5), // date peremption
                                    reader.IsDBNull(6) ? null : reader.GetDateTime(6), // date controle
                                    reader.IsDBNull(7) ? null : reader.GetDateTime(7), // date prochain controle
                                    reader.GetBoolean(8), // stock
                                    reader.IsDBNull(9) ? null : reader.GetString(9) // vehicule_id
                ));
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return liste;
        }

        public override Materiel_DAL? GetById(string id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Materiels]
                                     WHERE code_barre=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            Materiel_DAL m = null;


            while (reader.Read()) //j'ai trouvé une ligne
            {
                                 
                m = new Materiel_DAL(id, //Id
                                    reader.GetString(1), // nom
                                    reader.GetInt32(2), // categorieID
                                    reader.GetSqlInt32(3).IsNull ? null : reader.GetInt32(3),  // nb_utilisation
                                    reader.GetSqlInt32(4).IsNull ? null : reader.GetInt32(4),  // nb_utilisation MAX
                                    reader.IsDBNull(5) ? null : reader.GetDateTime(5), // date peremption
                                    reader.IsDBNull(6) ? null : reader.GetDateTime(6), // date controle
                                    reader.IsDBNull(7) ? null : reader.GetDateTime(7), // date prochain controle
                                    reader.GetBoolean(8), // stock
                                    reader.IsDBNull(9) ? null : reader.GetString(9) // vehicule_id
                );
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return m;
        }

        public override Materiel_DAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override Materiel_DAL Insert(Materiel_DAL m)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO [dbo].[Materiels]
                                           ([code_barre]
                                           ,[nom]
                                           ,[catégorie_id]
                                           ,[nb_utilisation]
                                           ,[nb_utilisation_max]
                                           ,[date_peremption]
                                           ,[date_controle]
                                           ,[date_prochain_controle]
                                           ,[stock]
                                           ,[vehicule_id])
                                         VALUES
                                           (@code_barre
                                           ,@nom
                                           ,@catégorie_id
                                           ,@nb_utilisation
                                           ,@nb_utilisation_max
                                           ,@date_peremption
                                           ,@date_controle
                                           ,@date_prochain_controle
                                           ,@stock
                                           ,@vehicule_id); select scope_identity()";

            Commande.Parameters.Add(new SqlParameter("@code_barre", m.CodeBarre));
            Commande.Parameters.Add(new SqlParameter("@nom", m.Nom));
            Commande.Parameters.Add(new SqlParameter("@catégorie_id", m.Categorie_ID));
            Commande.Parameters.Add(new SqlParameter("@nb_utilisation", m.Nb_utilisation??(object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@nb_utilisation_max", m.Nb_utilisation_max??(object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@date_peremption", m.Date_peremption ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@date_controle", m.Date_controle ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@date_prochain_controle", m.Date_prochain_controle ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@stock", m.Stock));
            Commande.Parameters.Add(new SqlParameter("@vehicule_id", m.Vehicule_ID ?? (object)DBNull.Value));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return m;
        }

        public override Materiel_DAL Update(Materiel_DAL m)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[Materiels]
                                           set
                                           [nom]=@nom
                                           ,[catégorie_id]=@catégorie_id
                                           ,[nb_utilisation]=@nb_utilisation
                                           ,[nb_utilisation_max]=@nb_utilisation_max
                                           ,[date_peremption]=@date_peremption
                                           ,[date_controle]=@date_controle
                                           ,[date_prochain_controle]=@date_prochain_controle
                                           ,[vehicule_id]=@vehicule_id
                                           ,[stock]=@stock
                                     WHERE code_barre=@code_barre";

            Commande.Parameters.Add(new SqlParameter("@code_barre", m.CodeBarre));
            Commande.Parameters.Add(new SqlParameter("@nom", m.Nom));
            Commande.Parameters.Add(new SqlParameter("@catégorie_id", m.Categorie_ID));
            Commande.Parameters.Add(new SqlParameter("@nb_utilisation", m.Nb_utilisation ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@nb_utilisation_max", m.Nb_utilisation_max ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@date_peremption", m.Date_peremption ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@date_controle", m.Date_controle ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@date_prochain_controle", m.Date_prochain_controle ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@stock", m.Stock));
            Commande.Parameters.Add(new SqlParameter("@vehicule_id", m.Vehicule_ID ?? (object)DBNull.Value));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return m;
        }
    }
}
