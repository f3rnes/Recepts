using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.Entity;
using System.Data;
using ReceptsAPI.Contacts.UsersContacts.CreateUsers;
using ReceptsAPI.Repository.Interface;
using ReceptsAPI.Contacts.UsersContancts.DeleteUsers;
using ReceptsAPI.Contacts.ReceptsContacts.CreateRecepts;
using ReceptsAPI.Contacts.UsersContancts.CreateUsers;
using ReceptsAPI.Contacts.ReceptsContacts.GetRecepts;
using ReceptsAPI.Contacts.UsersContancts.GetUsers;
using ReceptsAPI.Contacts.UsersContancts.GetOneUser;




namespace ReceptsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;


        public UserController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }


        [HttpPatch]
        [Authorize]
        public ActionResult Update([FromBody] UpdateUserRequest request)
        {
            string? userName = HttpContext.User.Identity.Name;

            if (int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }
            bool checkbool = _repository.Update(new User { Id = userId, FirstName = request.FirstName, LastName = request.Lastname, Login = request.Login, Password = request.Password });
            if (checkbool == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Authorize("Admin")]
        public ActionResult Delete([FromBody] DeleteUserRequest request)
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
        [HttpPost]
        [Authorize("Admin")]
        public ActionResult<int> CreateUsers([FromBody] CreateUsersRequest request)
        {
            string? userName = HttpContext.User.Identity.Name;

            if (int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }

            int? check = _repository.Create(new User { Id = userId, FirstName = request.FirstName, LastName = request.LastName, PFP = request.PFP, Role = request.Role, Login = request.Login, Password = request.Password });


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
        public List<GetUsersResponse> GetUsers()
        {
            return _repository.GetAll().Select(item => new GetUsersResponse(item.Id, item.FirstName, item.LastName, item.Role)).ToList();
        }
        [HttpGet]
        public ActionResult<User> GetOneUsers()
        {
            string? userName = HttpContext.User.Identity.Name;

            if (int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }
            return _repository.GetById(userId);
            
        }
    }
}
