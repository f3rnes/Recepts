using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using ReceptsAPI.Contacts.ReceptsContacts.CreateRecepts;
using ReceptsAPI.Entity;
using ReceptsAPI.Contacts.CommentsContacts.CreateComments;
using ReceptsAPI.Contacts.ReceptsContacts.GetRecepts;
using ReceptsAPI.Contacts.CommentsContacts.GetComments;
using ReceptsAPI.Contacts.CommentsContacts.GetOneComments;
using ReceptsAPI.Contacts.CommentsContacts.UpdateComments;
using ReceptsAPI.Contacts.ReceptsContacts.UpdateRecepts;
using ReceptsAPI.Contacts.ReceptsContacts.DeleteRecepts;
using ReceptsAPI.Contacts.CommentsContacts.DeleteComments;
using ReceptsAPI.Contacts.CommentsContacts.DeleteUserComments;






namespace ReceptsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        public CommentController(ICommentRepository commentRepository)
        {
            _repository = commentRepository;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<int> CreateComments([FromBody] CreateCommentsRequest request)
        {
            string? userName = HttpContext.User.Identity.Name;

            if (int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }

            int? check = _repository.Create(new Comment { Id = userId, ReceptId = request.ReceptId, UserId = request.UserId, Description = request.Decription, Mood = request.Mood });


            if (check == null)
            {
                return BadRequest();
            }
            else
            {
                return check;
            }

        }


        [HttpGet]
        public List<GetCommentsResponse> GetComments()
        {
            return _repository.GetAll().Select(item => new GetCommentsResponse(item.Id, item.ReceptId, item.UserId, item.Mood, item.Description)).ToList();
        }

        [HttpGet]
        public ActionResult<Comment> GetOneComments()
        {
            string? userName = HttpContext.User.Identity.Name;

            if (int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }
            return _repository.GetById(userId);
            //почему то нихуя не проверяем
        }

        [HttpPatch]
        [Authorize]
        public ActionResult<bool> UpdateComments([FromBody] UpdateCommentsRequest request)
        {


            bool boolcheck = _repository.Update(new Comment { Mood = request.Mood, Description = request.Description });


            if (boolcheck == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);
            }


        }
        [HttpDelete]
        [Authorize("Admin")]
        public ActionResult<bool> DeleteComments([FromBody] DeleteCommentsRequest request)
        {
            string? userName = HttpContext.User.Identity.Name;
            

            if (int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }
            
            bool checkbool = _repository.Delete(userId);
            if (checkbool == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);

            }


        }
        [HttpDelete]
        [Authorize]
        public ActionResult<bool> DeleteUserComments([FromBody] DeleteUserCommentsRequest request)
        {
            string? userName = HttpContext.User.Identity.Name;

            if (int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }

            if (userId != userId && userId != request.UserId) 
            {
                return BadRequest();

            }
            bool checkbool = _repository.DeleteUser(userId);
            if (checkbool == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);

            }


        }

    }



}
