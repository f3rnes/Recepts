using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository
{
    public interface ICommentRepository
    {
        public bool Create(Comment item);
        public bool Update(Comment item);
        public bool Delete(Comment item);



    }
}
