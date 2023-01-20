using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository.Representative;
using WebApplication1.Repository.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeController : ControllerBase
    {
        public readonly IRepresentative_repo _hr;
        public RepresentativeController(IRepresentative_repo hr)
        {
            _hr = hr;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
            var Hospitals = await _hr.GetAllRepresentativesAsync();
            return Ok(Hospitals);
        }
        [HttpPost("")]
        [ActionName(nameof(AddRepresentative))]
        public async Task<IActionResult> AddRepresentative([FromBody] RepresentativeModel Rep)
        {
            var RepId = await _hr.AddRepresentativesAsync(Rep);
            return Ok(RepId) /*CreatedAtAction(nameof(GetHospitalById),new { HospitalId= HospitalId ,controller="Hospitals"}, HospitalId)*/;
        }

    }
}
