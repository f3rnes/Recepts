using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        public bool SetRefreshToken(string refreshToken, int userId);
    }
}
