using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.Contacts.CreateRecepts;
using ReceptsAPI.Contacts.GetRecepts;
using ReceptsAPI.Entity;
using ReceptsAPI.Repository;
using System.Data;

namespace ReceptsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceptController : ControllerBase
    {
        private readonly IReceptRepository _repository;
        public ReceptController(IReceptRepository receptRepository)
        {
            _repository = receptRepository;
        }


        [HttpGet]
        public List<GetReceptsResponse> GetRecepts()
        {
            return _repository.GetAll().Select(item => new GetReceptsResponse(item.Id, item.Name, item.Photo, $"{item.Admin.FirstName} {item.Admin.LastName}")).ToList();
        }

        [HttpPost]
        [Authorize]
        public ActionResult<int> CreateRecepts([FromBody] CreateReceptsRequest request)
        {
            string? userName = HttpContext.User.Identity.Name;

            if(int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }

            int? check = _repository.Create(new Recept { AdminId = userId, Name = request.Name, Description = request.Description, Photo = request.Photo, Weight = request.Weight, Ingredients = request.Ingredients });
           
           
            if (check == null)
            {
                return BadRequest();
            }
            else
            {
                return check;
            }



        }
    } 
}
