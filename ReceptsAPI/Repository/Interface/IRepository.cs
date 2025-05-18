using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository.Interface
{
    public interface IRepository<T>
    {
        public int? Create(T item);
        public T? GetById(int id);
        public List<T> GetAll();
        public bool Update(T item);
        public bool Delete(int id);
    }
}
