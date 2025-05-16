using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.Contacts.ReceptsContacts.CreateRecepts;
using ReceptsAPI.Contacts.ReceptsContacts.GetRecepts;
using ReceptsAPI.Entity;
using ReceptsAPI.Repository;
using System.Data;
using ReceptsAPI.Contacts.ReceptsContacts.DeleteRecepts;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using ReceptsAPI.Contacts.ReceptsContacts.GetOneRecepts;
using ReceptsAPI.Contacts.ReceptsContacts.UpdateRecepts;




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
        [HttpDelete]
        [Authorize("Admin")]
        public ActionResult<bool> DeleteRecepts([FromBody] DeleteReceptsRequest request)
        {
            // взять айди пользователя

            bool checkbool = _repository.Delete();
            if (checkbool == false)
            {
                return BadRequest();
            }
            if (checkbool == true)
            {
                return Ok();
            }

        }
        [HttpGet] 
        public Recept<GetOneReceptsResponse> GetOneRecepts([FromBody] GetOneReceptsResponse request)
        {
            //dpznm fqlb
            return _repository.GetById();

        }
        [HttpPatch]
        public ActionResult<bool> UpdateRecepts([FromBody] GetOneReceptsResponse request)
        {
            

            bool boolcheck = _repository.Update(new Recept { Name = request.Name, Description = request.Description, Photo = request.Photo, Weight = request.Weight, Ingredients = request.Ingredients });


            if (boolcheck == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(); 
            }
           

        }
    } 
}
