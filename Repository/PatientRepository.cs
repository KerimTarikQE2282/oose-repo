using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<PatientsModel>> GetAllPatientsAsync()
        {
            var records =await _context.Patients.Select(x=>new PatientsModel()
            {
                firstName=x.firstName,
                middleName=x.middleName,
                lastName=x.lastName,
                Kebele=x.Kebele,
                kifleketema=x.kifleketema,
                wereda=x.wereda,
                DOB=x.DOB,
                phoneNumber=x.phoneNumber,
                emergencyPhone=x.emergencyPhone

            }).ToListAsync();
            return records;
        }

        
        public async Task<PatientsModel> Search(string phoneNumber)
        {
            var records = await _context.Patients.Where(x=>x.phoneNumber==phoneNumber).Select(x => new PatientsModel()
            {
                firstName = x.firstName,
                middleName = x.middleName,
                lastName = x.lastName,
                Kebele = x.Kebele,
                kifleketema = x.kifleketema,
                wereda = x.wereda,
                DOB = x.DOB,
                phoneNumber = x.phoneNumber,
                emergencyPhone = x.emergencyPhone

            }).FirstOrDefaultAsync();
            // Kerim what if instead of returning the first hit, we counted all of the matching and 
            // if there are multiple results with the same phone number we search by name
            // so we also add first name to the parameter and an if...else statement to handle it  
            return records;
        }
        public async Task<string> RegisterPatientAsync(PatientsModel Patient)
        {
            var pat = new Patients()
            {
                firstName = Patient.firstName,
                middleName = Patient.middleName,
                lastName= Patient.lastName,
                Kebele= Patient.Kebele,
                kifleketema= Patient.kifleketema,
                wereda= Patient.wereda,
                DOB= Patient.DOB,
                phoneNumber= Patient.phoneNumber,
                emergencyPhone= Patient.emergencyPhone
                    };
            _context.Patients.Add(pat);
            await _context.SaveChangesAsync();
            return pat.firstName;
        }
    }
}

