using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Hospital;
using WebApplication1.Repository.Vitals;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VitalsController : Controller
    {
        
        public readonly IVitalsRepo _vr;
        public VitalsController(IVitalsRepo vr)
        {
            _vr = vr;
        }
        [HttpPost("")]
        [ActionName(nameof(AddVitals))]
        public async Task<IActionResult> AddVitals([FromBody] VitalsModel vital)
        {
            var VitalsId = await _vr.AddVitals(vital);
            return Ok(VitalsId);
        }
        [HttpPost("")]
        [ActionName(nameof(GetVitals))]
        public async Task<IActionResult> GetVitals([FromBody]Search Email)
        {
            var Vitals = await _vr.PatientVitals(Email.Email);
            return Ok(Vitals);
        }
    }
}
