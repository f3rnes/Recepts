using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.Entity;
using ReceptsAPI.Repository;
using System.Data;

namespace ReceptsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public partial class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public record CreateUserRequest(string FirstName, string Lastname, string Role, string Login, string Password);
        public record DeleteUserRequest(int Id);

        public UserController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        [HttpGet]
        public ActionResult Create([FromBody] CreateUserRequest request)
        {

            bool checkbool = _repository.Create(new User { FirstName = request.FirstName, LastName = request.Lastname, Role = request.Role, Login = request.Login, Password = request.Password });
            if (checkbool == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public ActionResult Update([FromRoute] CreateUserRequest request)
        {
            bool checkbool = _repository.Update(new User {FirstName = request.FirstName, LastName = request.Lastname, Role = request.Role, Login = request.Login, Password = request.Password });
            if (checkbool == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete]

        public ActionResult DeleteTodo([FromRoute] DeleteUserRequest request)
        {
            bool checkbool = _repository.Delete(request.Id);
            if (checkbool == true)
            {
                return Ok();

            }
            else
            {
                return BadRequest();

            }
        }

    }
}
