using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class VehiculeIntervention_Depot_DAL : Depot_DAL<VehiculeIntervention_DAL>
    {
        public override void Delete(int id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[VechiculesInterventions]
                                     WHERE id_vehicule_intervention=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }

        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<VehiculeIntervention_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[VechiculesInterventions]";


            var reader = Commande.ExecuteReader();

            var liste = new List<VehiculeIntervention_DAL>();

            while (reader.Read()) //j'ai trouvé une ligne
            {
                var id = reader.GetInt32(0);

                liste.Add(new VehiculeIntervention_DAL(id, //Id
                                    reader.GetInt32(1), // id intervention
                                    reader.GetString(2) // immatriculation vehicule
                ));
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return liste;
        }

        public override VehiculeIntervention_DAL GetById(int id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[VechiculesInterventions]
                                     WHERE id_vehicule_intervention=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            VehiculeIntervention_DAL i = null;

            if (reader.Read()) //j'ai trouvé une ligne
            {

                i = new VehiculeIntervention_DAL(id, //Id
                                    reader.GetInt32(1), // id intervention
                                    reader.GetString(2) // immatriculation vehicule
                );
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return i;
        }

        public override VehiculeIntervention_DAL GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override VehiculeIntervention_DAL Insert(VehiculeIntervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO [dbo].[VechiculesInterventions]
                                           (
                                           [id_intervention], [immatriculation])
                                         VALUES
                                           (@id_intervention, @immatriculation); select scope_identity()";

            Commande.Parameters.Add(new SqlParameter("@id_intervention", p.IdIntervention));
            Commande.Parameters.Add(new SqlParameter("@immatriculation", p.ImmatriculationVehicule));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }

        public override VehiculeIntervention_DAL Update(VehiculeIntervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[VechiculesInterventions]
                                           set
                                           [id_intervention]=@id_intervention,
                                           [immatriculation]=@immatriculation
                                     WHERE id_intervention=@id_intervention";

            Commande.Parameters.Add(new SqlParameter("@id_intervention", p.IdIntervention));
            Commande.Parameters.Add(new SqlParameter("@immatriculation", p.ImmatriculationVehicule));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }
    }
}
