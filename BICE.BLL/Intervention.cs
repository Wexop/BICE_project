using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.BLL
{
    public class Intervention
    {
        public int Id_intervention { get; private set; }
        public DateTime Date_intervention { get; private set; }

        public Intervention(int id, DateTime dateIntervention) 
        { 
            Id_intervention = id;
            Date_intervention= dateIntervention;
        }
    }
}
