using ReceptsAPI.Entity;

namespace ReceptsAPI.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private ApplicationContext _context;
        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(Comment item)
        {
            _context.Comments.Add(item);

            return _context.SaveChanges() > 0;
        }

        public bool Delete(Comment item)
        {
            _context.Comments.Remove(item);

            return _context.SaveChanges() > 0;
        }

        public bool Update(Comment item)
        {
            _context.Comments.Update(item);

            return _context.SaveChanges() > 0;
        }
    }
}
