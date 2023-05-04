using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class MaterielIntervention_DAL
    {
        public int IdVehiculeIntervention { get; set; }
        public string CodeBarreMateriel { get; set; }

        public MaterielIntervention_DAL(int idVehiculeIntervention, string codeBarre)
            => (IdVehiculeIntervention, CodeBarreMateriel) = (idVehiculeIntervention, codeBarre);
    }
}
