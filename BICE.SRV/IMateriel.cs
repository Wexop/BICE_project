using BICE.DTO;

namespace BICE.SRV
{
    public interface IMateriel_SRV<Type_DTO>
                 where Type_DTO : Materiel_DTO
    {
        Type_DTO GetById(string id);
        IEnumerable<Type_DTO> GetAll();
        Type_DTO Ajouter(Type_DTO m);
        Type_DTO Modifier(Type_DTO m);
        void Supprimer(string m);
    }
}