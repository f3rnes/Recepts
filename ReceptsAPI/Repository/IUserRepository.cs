using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();

        public bool Create(User user);

        public bool Update(User user);
        public User GetById(int id);
        public bool Delete(int id);
        public bool SetRefreshToken(string refreshToken, int userId);

    }
}
