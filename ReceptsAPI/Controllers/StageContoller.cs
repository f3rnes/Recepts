using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ReceptsAPI.Contacts.StagesContacts.CreateStages;
using ReceptsAPI.Repository.Interface;
using ReceptsAPI.Contacts.ReceptsContacts.DeleteRecepts;
using ReceptsAPI.Contacts.StagesContacts.DeleteStages;
using ReceptsAPI.Contacts.StagesContacts.UpdateStages;
using ReceptsAPI.Contacts.ReceptsContacts.UpdateRecepts;
using ReceptsAPI.Contacts.StagesContacts.GetStages;
using ReceptsAPI.Contacts.ReceptsContacts.GetRecepts;
using ReceptsAPI.Contacts.StagesContacts.GetOneStages;




namespace ReceptsAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StageController : ControllerBase
    {
        private readonly IStageRepository _repository;
        public StageController(IStageRepository stageRepository)
        {
            _repository = stageRepository;
        }




        [HttpPost]
        [Authorize]
        public ActionResult<int> CreateStages([FromBody] CreateStagesRequest request)
        {


            int? check = _repository.Create(new Stage { ReceptId = request.ReceptId, StageNumber = request.StageNumber, Photo = request.Photo, Description = request.Description });


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
        public ActionResult<bool> DeleteStages([FromBody] DeleteStagesRequest request)
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
        [HttpPatch]
        [Authorize("Admin")]
        public ActionResult<bool> UpdateStages([FromBody] UpdateStagesRequest request)
        {


            bool boolcheck = _repository.Update(new Stage{StageNumber = request.StageNumber , Photo = request.Photo, Description = request.Description});


            if (boolcheck == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);
            }


        }
        [HttpGet]
        public List<GetStagesResponse> GetStages()
        {
            return _repository.GetAll().Select(item => new GetStagesResponse(item.Id, item.ReceptId,item.StageNumber, item.Photo, item.Description)).ToList();
        }
        [HttpGet]
        public ActionResult<Stage> GetOneStages()
        {
            string? userName = HttpContext.User.Identity.Name;

            if (int.TryParse(userName, out int userId) == false)
            {
                return BadRequest();
            }
            return _repository.GetById(userId);
            //почему то нихуя не проверяем
        }
    }
}

