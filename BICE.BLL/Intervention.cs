using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.BLL
{
    internal class Intervention
    {
        public int Id_intervention { get; set; }
        public DateTime Date_intervention { get; set; }

        public Intervention(int id, DateTime dateIntervention) 
        { 
            Id_intervention = id;
            Date_intervention= dateIntervention;
        }
    }
}
