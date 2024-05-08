using LXP.Common.ViewModels;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LXP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IService _services;

        public LoginController (IService services)
        {
            _services = services;
        }



        [HttpPost]
        
        public async Task<ActionResult> CheckLearner([FromBody]LoginModel loginmodel)
        {


            // Since CheckLearner now returns LoginRole, we capture it in a variable of type LoginRole

            LoginRole data = await _services.CheckLearner(loginmodel);

            // If you want to return the whole LoginRole object
            return Ok(data);

        }






    }
}
