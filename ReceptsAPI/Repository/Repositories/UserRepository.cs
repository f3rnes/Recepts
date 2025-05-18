using ReceptsAPI.Entity;
using ReceptsAPI.Repository.Interface;

namespace ReceptsAPI.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int? Create(User item)
        {
            _context.Users.Add(item);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return item.Id;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if(user != null)
                return false;

            _context.Users.Remove(user);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int Id)
        {
            return _context.Users.Where(user => user.Id == Id).FirstOrDefault();
        }

        public bool SetRefreshToken(string refreshToken, int userId)
        {
            User? user = _context.Users.Where(user => user.Id == userId).FirstOrDefault();

            if (user == null)
                return false;

            user.RefreshToken = refreshToken;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }

        public bool Update(User item)
        {
            _context.Users.Update(item);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
