using ClinicService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        [HttpGet("get-all", Name = "PetGetAll")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok();
        }
    }
}
