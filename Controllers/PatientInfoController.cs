using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> Search(string phoneNumber)
        {
            var Patient = await PatientRepo.Search(phoneNumber);
            if (Patient == null)
            {
                return NotFound();
            }
            return Ok(Patient);
        }
        [HttpPost("")]
        public async Task<IActionResult> RegisterPatient([FromBody]PatientsModel patientModel)
        {
            Console.Write(patientModel);
            var id = await PatientRepo.RegisterPatientAsync(patientModel);
            return CreatedAtAction(nameof(Search), new { id = id, controller = "Patients" }, id);
        }

    }

}
