using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository

{
    public interface IReceptRepository
    {
    public bool Create(Recept item);
    public bool Update(Recept item);
    public bool Delete(Recept item);

    }
}
