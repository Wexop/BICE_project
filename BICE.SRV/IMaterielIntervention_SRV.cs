using BICE.DTO;

namespace BICE.SRV
{
    public interface IMaterielIntervention_SRV<Type_DTO> : IBase_SRV<Type_DTO>
    {
        Type_DTO GetById(int idVehiculeIntervention, string codeBarre);
        void Supprimer(int idVehiculeIntervention, string codeBarre);
    }
}