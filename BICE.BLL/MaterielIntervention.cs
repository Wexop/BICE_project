using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.BLL
{
    public class MaterielIntervention
    {
        public int IdVehiculeIntervention { get; set; }
        public string CodeBarreMateriel { get; set; }

        public MaterielIntervention (int idVehiculeIntervention, string codeBarre)
        {
            IdVehiculeIntervention= idVehiculeIntervention;
            CodeBarreMateriel= codeBarre;
        }
    }
}
