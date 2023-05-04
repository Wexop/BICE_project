using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    internal class MaterielIntervention_Depot_DAL : Depot_DAL<MaterielIntervention_DAL>
    {
        public void Delete(int idVehiculeIntervention, string codeBarre )
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[MaterielsInterventions]
                                     WHERE id_vehicule_intervention=@idVehiculeIntervention and code_barre_materiel=@codeBarre";

            Commande.Parameters.Add(new SqlParameter("@idVehiculeIntervention", idVehiculeIntervention));
            Commande.Parameters.Add(new SqlParameter("@codeBarre", codeBarre));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<MaterielIntervention_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[MaterielsInterventions]";


            var reader = Commande.ExecuteReader();

            var liste = new List<MaterielIntervention_DAL>();

            while (reader.Read()) //j'ai trouvé une ligne
            { 

                liste.Add(new MaterielIntervention_DAL(reader.GetInt32(0), //IdVehiculeIntervention
                                    reader.GetString(1) // code barre
                ));
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return liste;
        }

        public override MaterielIntervention_DAL GetById(int idVehiculeIntervention, string codeBarre)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[MaterielsInterventions]
                                     WHERE id_vehicule_intervention=@idVehiculeIntervention and code_barre_materiel=@codeBarre";

            Commande.Parameters.Add(new SqlParameter("@idVehiculeIntervention", idVehiculeIntervention));
            Commande.Parameters.Add(new SqlParameter("@codeBarre", codeBarre));

            var reader = Commande.ExecuteReader();

            MaterielIntervention_DAL mi = null;

            if (reader.Read()) //j'ai trouvé une ligne
            {

                mi = new MaterielIntervention_DAL(reader.GetInt32(0), //IdVehiculeIntervention
                                    reader.GetString(1) // code barre
                );
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return mi;
        }

        public override MaterielIntervention_DAL GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override MaterielIntervention_DAL Insert(MaterielIntervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO [dbo].[MaterielsInterventions]
                                           (
                                           [id_vehicule_intervention],
                                            [code_barre_materiel]
)
                                         VALUES
                                           (@idVehiculeIntervention, @codeBarre); select scope_identity()";

            Commande.Parameters.Add(new SqlParameter("@idVehiculeIntervention", p.IdVehiculeIntervention));
            Commande.Parameters.Add(new SqlParameter("@codeBarre", p.CodeBarreMateriel));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }

        public override MaterielIntervention_DAL Update(MaterielIntervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[MaterielsInterventions]
                                           set
                                           [id_vehicule_intervention]=@idVehiculeIntervention
                                           [code_barre_materiel]=@codeBarre
                                     WHERE id_vehicule_intervention=@idVehiculeIntervention and code_barre_materiel=@codeBarre";

            Commande.Parameters.Add(new SqlParameter("@idVehiculeIntervention", p.IdVehiculeIntervention));
            Commande.Parameters.Add(new SqlParameter("@codeBarre", p.CodeBarreMateriel));

            Commande.ExecuteScalar();

            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }
    }
}
