using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Patient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientInfoController : ControllerBase
    {
        private readonly IPatientRepository PatientRepo;

        public PatientInfoController(IPatientRepository patientRepository)
        {
        PatientRepo = patientRepository;
        }
        /*[HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var Patients =await PatientRepo.GetAllPatientsAsync();
            return Ok(Patients);
        }*/
        [HttpPost("")]
        public async Task<IActionResult> Search ([FromBody]Search Email)
        {
            var Patient = await PatientRepo.Search(Email.Email);
            if (Patient == null)
            {
                return NotFound();
            }
            return Ok(Patient);
        }
        [HttpPost("")]
        [ActionName(nameof(RegisterPatient))]
        public async Task<IActionResult> RegisterPatient([FromBody]PatientsModel patientModel)
        {
            
            var id = await PatientRepo.RegisterPatientAsync(patientModel);
         
            return Ok(id);
        }

    }

}
