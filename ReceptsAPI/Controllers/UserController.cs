using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.Entity;
using System.Data;
using ReceptsAPI.Contacts.UsersContacts.CreateUsers;
using ReceptsAPI.Repository.Interface;


namespace ReceptsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public  class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;


        public UserController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        
        [HttpPatch]
        [Authorize]
        public ActionResult Update([FromRoute] CreateUserRequest request)
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);

            bool checkbool = _repository.Update(new User {Id = userId, FirstName = request.FirstName, LastName = request.Lastname, Login = request.Login, Password = request.Password });
            if (checkbool == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }

            [HttpDelete("{id:int}")]
            [Authorize("Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            bool checkbool = _repository.Delete(id);
            if (checkbool == true)
            {
                return NoContent();

            }
            else
            {
                return BadRequest();

            }
        }

    }
}
