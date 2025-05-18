using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ReceptsAPI.Contacts.StagesContacts.CreateStages;
using ReceptsAPI.Repository.Interface;

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
            public ActionResult<int> CreateStages([FromRoute] CreateStagesRequest request)
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
        }
    }

