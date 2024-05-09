using LXP.Common.ViewModels;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LXP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePasswordController : ControllerBase
    {

        private readonly IService _services;

        public UpdatePasswordController(IService services)
        {
            _services = services;
        }




        [HttpPut]


        public async Task<ActionResult> LeanerUpdatePassword([FromBody] UpdatePassword updatepassword)
        {
            var result= await _services.UpdatePassword(updatepassword);

            return Ok (result);
        }


    }
}

