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

        public int? Create(Stage item)
        {
            _context.Stages.Add(item);

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
            var stage = _context.Stages.FirstOrDefault(x => x.Id == id);

            if (stage != null)
                return false;

            _context.Stages.Remove(stage);

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

        public List<Stage> GetAll()
        {
            return _context.Stages.ToList();
        }

        public Stage? GetById(int Id)
        {
            return _context.Stages.Where(stage => stage.Id == Id).FirstOrDefault();
        }

        public bool Update(Stage item)
        {
            _context.Stages.Update(item);

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
