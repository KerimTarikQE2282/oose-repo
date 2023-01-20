using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Hospital;
using WebApplication1.Repository.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUsersController : ControllerBase
    {
        public readonly IUsersRepository _hr;
        public SystemUsersController(IUsersRepository hr)
        {
            _hr = hr;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
            var Hospitals = await _hr.GetAllUsersAsync();
            return Ok(Hospitals);
        }
        [HttpGet("{UserId}")]
       /* public async Task<IActionResult> GetUserById([FromRoute] int UserId)
        {
            var Hospital = await _hr.GetHospitalsAsync(_HospitalId);
            if (Hospital == null)
            {
                return NotFound();
            }
            return Ok(Hospital);
        }*/
        [HttpPost("")]
        [ActionName(nameof(AddUser))]
        public async Task<IActionResult> AddUser([FromBody] SystemUsersModel user)
        {
            var UserId = await _hr.AddUserAsync(user);
            if (UserId == null)
            {
                return null;
            }
            return Ok(UserId) /*CreatedAtAction(nameof(GetHospitalById),new { HospitalId= HospitalId ,controller="Hospitals"}, HospitalId)*/;
        }

    }
}
