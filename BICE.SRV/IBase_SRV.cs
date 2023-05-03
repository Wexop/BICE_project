using BICE.DTO;

namespace BICE.SRV
{
    public interface IBase_SRV<Type_DTO>
    {
        Type_DTO GetById(string id);
        Type_DTO GetById(int id);
        IEnumerable<Type_DTO> GetAll();
        void Ajouter(Type_DTO o);
        void Modifier(Type_DTO o);
        void Supprimer(string id);
        void Supprimer(int id);
    }
}