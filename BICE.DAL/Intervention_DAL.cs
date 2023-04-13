using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    internal class Intervention_DAL
    {
        public int Id_intervention { get; set; }
        public DateTime Date_intervention { get; set; }
        public Intervention_DAL(int id_intervention, DateTime date_intervention)
            => (Id_intervention,  Date_intervention) = (id_intervention, date_intervention);
    }
}
