using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository
{
    public class StageRepository : IStageRepository
    {
        private ApplicationContext _context;
        public StageRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(Stage item)
        {
            _context.Stages.Add(item);

            return _context.SaveChanges() > 0;
        }

        public bool Delete(Stage item)
        {
            _context.Stages.Remove(item);

            return _context.SaveChanges() > 0;
        }

        public bool Update(Stage item)
        {
            _context.Stages.Update(item);

            return _context.SaveChanges() > 0;
        }
    }
}
