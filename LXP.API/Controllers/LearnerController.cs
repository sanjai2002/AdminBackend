using LXP.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LXP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private ILearnerService _learnerService;
        public LearnerController(ILearnerService learnerService) 
        {
            _learnerService = learnerService;
        }
        [HttpGet]
        public ActionResult GetAllLearners()
        {
            var learners = _learnerService.GetAll();
            return Ok(learners);
        }
    }
}
