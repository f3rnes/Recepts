using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository.Interface
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public bool DeleteUser(int Id);
    }
}
