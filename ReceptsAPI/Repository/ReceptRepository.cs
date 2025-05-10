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
       public int? Create(Recept item)
        {
            _context.Recepts.Add(item);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
                //return null;
            }

            return item.Id;
        }

        public bool Delete(int id)
        {
            var recept = _context.Recepts.FirstOrDefault(x => x.Id == id);

            if(recept != null)
                return false;

            _context.Recepts.Remove(recept);

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

        public List<Recept> GetAll()
        {
            return _context.Recepts.ToList();
        }

        public Recept? GetById(int Id)
        {
            return _context.Recepts.Where(recept => recept.Id == Id).FirstOrDefault();
        }

       
        public bool Update(Recept item)
        {
            _context.Recepts.Update(item);

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
