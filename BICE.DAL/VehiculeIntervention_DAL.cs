using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class VehiculeIntervention_DAL
    {
        public int IdVehiculeIntervention { get; set; }
        public int IdIntervention { get; set; }
        public string ImmatriculationVehicule { get; set; }

        public VehiculeIntervention_DAL(int idVehiculeIntervention, int idIntervention, string immatriculationVehicule)
            => (IdVehiculeIntervention, IdIntervention, ImmatriculationVehicule) = (idVehiculeIntervention, idIntervention, immatriculationVehicule);
    }
}
