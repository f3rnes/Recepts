using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository
{
    public class ReceptRepository : IReceptRepository
    {
        private ApplicationContext _context;
        public ReceptRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(Recept item)
        {
            _context.Recepts.Add(item);

            return _context.SaveChanges() > 0;
        }

        public bool Delete(Recept item)
        {
            _context.Recepts.Remove(item);

            return _context.SaveChanges() > 0;
        }

        public bool Update(Recept item)
        {
            _context.Recepts.Update(item);

            return _context.SaveChanges() > 0;
        }
    }
}
