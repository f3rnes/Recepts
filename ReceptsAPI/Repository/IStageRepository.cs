using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository
{
    public interface IStageRepository
    {

        public bool Create(Stage item);

        public bool Update(Stage item);

        public bool Delete(Stage item);
    }
}
