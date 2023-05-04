using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public interface IMaterielIntervention_Depot_DAL<Type_DAL> : IDepot_DAL<Type_DAL>
    {
        public Type_DAL GetById(int idVehiculeIntervention, string codeBarre);
        public void Delete(int idVehiculeIntervention, string codeBarre);
    }
}
