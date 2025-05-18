using Microsoft.AspNetCore.Authorization;
using ReceptsAPI.Entity;
using ReceptsAPI.Repository.Interface;

namespace ReceptsAPI.Repository.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private ApplicationContext _context;
        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int? Create(Comment item)//
        {
            _context.Comments.Add(item);

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
            var comment = _context.Comments.FirstOrDefault(x => x.Id == id);

            if (comment != null)
                return false;

            _context.Comments.Remove(comment);

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
        
        public bool DeleteUser(int id)
        {
     
            var comment = _context.Comments.FirstOrDefault(x => x.Id == id );

            if (comment != null)
                return false;

            _context.Comments.Remove(comment);

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

        public List<Comment> GetAll()//
        {
            return _context.Comments.ToList();
        }

        public Comment? GetById(int Id)//
        {
            return _context.Comments.Where(comment => comment.Id == Id).FirstOrDefault();
        }


        public bool Update(Comment item)//
        {
            _context.Comments.Update(item);

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
