using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.BLL
{
    public class VehiculeIntervention
    {
        public int IdVehiculeIntervention { get; set; }
        public int IdIntervention { get; set; }
        public string ImmatriculationVehicule { get; set; }

        public VehiculeIntervention(int idVehiculeIntervention, int idIntervention, string immatriculation)
        { 
            IdVehiculeIntervention= idVehiculeIntervention;
            IdIntervention= idIntervention;
            ImmatriculationVehicule= immatriculation;
        }
    }
}
