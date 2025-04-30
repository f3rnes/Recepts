using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public bool SetRefreshToken(string refreshToken, int userId);
    }
}
