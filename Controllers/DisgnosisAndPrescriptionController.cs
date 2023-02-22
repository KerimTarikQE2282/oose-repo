using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.DiagnosisRepo;
using WebApplication1.Repository.Hospital;
using WebApplication1.Repository.Patient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DisgnosisAndPrescriptionController : Controller
    {
        public readonly IdiagnosisRepo _hr;
        public DisgnosisAndPrescriptionController(IdiagnosisRepo hr)
        {
            _hr = hr;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddDiagnosis([FromBody] DisgnosisAndPrescription Diagnosis)
        {
            var HospitalId = await _hr.AddDiagnosis(Diagnosis);
            return Ok(HospitalId) /*CreatedAtAction(nameof(GetHospitalById),new { HospitalId= HospitalId ,controller="Hospitals"}, HospitalId)*/;
        }
    

             [HttpPost("")]
        public async Task<IActionResult> GetSymptomByEmail([FromBody] string Email)
        {
            var Diagnosis = await _hr.SearchDiagnosticAndPrescription(Email);
            if (Diagnosis == null)
            {
                return NotFound("not found");
            }
            return Ok(Diagnosis);
        }
    }
}
