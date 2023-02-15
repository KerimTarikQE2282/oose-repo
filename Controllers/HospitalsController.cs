using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Hospital;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        public readonly IHospitalReporitory _hr;
        public HospitalsController(IHospitalReporitory hr)
        {
            _hr = hr;
        }
        [HttpGet]
       public async Task<IActionResult> GetAllHospitals()
        {
            var Hospitals = await _hr.GetAllHospitalsAsync();
            return Ok(Hospitals);
        }
        /*   [HttpGet("{id}")]
           public async Task<IActionResult> GetHospitalById([FromRoute]int _HospitalId)
           {
               var Hospital = await _hr.GetHospitalsAsync(_HospitalId);
               return Ok(Hospital);
           }
       }*/
        [HttpGet("{_HospitalName}")]
        public async Task<IActionResult> GetHospitalByName([FromRoute] string _HospitalName)
        {
            var Hospital = await _hr.GetHospitalsAsync(_HospitalName);
            if (Hospital == null)
            {
                return NotFound();
            }
            return Ok(Hospital);
        }
        [HttpPost("")]
        [ActionName(nameof(AddHospital))]
        public async Task<IActionResult> AddHospital([FromBody]HospitalsModel hospital)
        {
            var HospitalId = await _hr.AddHospitalsAsync(hospital);
            return Ok(HospitalId) /*CreatedAtAction(nameof(GetHospitalById),new { HospitalId= HospitalId ,controller="Hospitals"}, HospitalId)*/;
        }
    }
}
