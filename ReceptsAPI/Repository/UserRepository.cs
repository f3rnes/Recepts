using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(User item)
        {
            _context.Users.Add(item);

            return _context.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            User? user = _context.Users.Where(user => user.Id == Id).FirstOrDefault();

            _context.Users.Remove(user);

            return _context.SaveChanges() > 0;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int Id)
        {
          return   _context.Users.Where(user => user.Id == Id).FirstOrDefault();


            
        }

        public bool SetRefreshToken(string refreshToken, int userId)
        {
            User? user = _context.Users.Where(user => user.Id == userId).FirstOrDefault();

            if (user == null)
                return false;

            user.RefreshToken = refreshToken;

            return _context.SaveChanges() > 0;

        }

    
    

        public bool Update(User item)
        {
            _context.Users.Update(item);

            return _context.SaveChanges() > 0;
        }
     
    }
}
