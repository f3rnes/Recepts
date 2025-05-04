using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public int? CreateRecepts([FromRoute] CreateReceptsResponse request)
        {

            bool checkbool = _repository.Create().Select(item => new CreateReceptsResponse(item.Id, item.Name, item.Description, item.Photo, item.Weight, item.Ingredients, $"{item.Admin.FirstName} {item.Admin.LastName}");

            if (checkbool == true)
            {
                return true ;
            }
            if (checkbool == false) 
            {
                return false;
            }



    }
}
