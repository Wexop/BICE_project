using BICE.DTO;

namespace BICE.SRV
{
    public interface IBase_SRV<Type_DTO>
    {
        Type_DTO GetById(string id);
        IEnumerable<Type_DTO> GetAll();
        void Ajouter(Type_DTO m);
        void Modifier(Type_DTO m);
        void Supprimer(string m);
    }
}