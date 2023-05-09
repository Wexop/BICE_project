using BICE.DTO;

namespace BICE.SRV
{
    public interface IMateriel_SRV<Type_DTO> : IBase_SRV<Type_DTO>
    {
        public void ModifierRetourInterventionUtiliser(Type_DTO m);
    }
}