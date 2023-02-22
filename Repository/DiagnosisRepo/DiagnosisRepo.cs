using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.DiagnosisRepo
{
    public class DiagnosisRepo: IdiagnosisRepo
    {
        public readonly ApplicationDbContext Context;
        public  DiagnosisRepo(ApplicationDbContext _context) { 
        Context= _context;
        }

        public async Task<int> AddDiagnosis(DisgnosisAndPrescription diagnosis)
        {
          
            var Diagnosis = new DisgnosisAndPrescription()
            {
               
                PatientId = diagnosis.PatientId,
                PatientName = diagnosis.PatientName,
                symptoms = diagnosis.symptoms,
                PatientEmail= diagnosis.PatientEmail,
                Part=diagnosis.Part,
                diagnosis = diagnosis.diagnosis,
                Prescription= diagnosis.Prescription,
            };
           Context.DisgnosisAndPrescription.Add(Diagnosis);
            await Context.SaveChangesAsync();
            return Diagnosis.DiagnosisId;
        }
       public async Task<List<DisgnosisAndPrescription>> SearchDiagnosticAndPrescription(string Email)
        {
            var records = await Context.DisgnosisAndPrescription.Where(x => x.PatientEmail == Email).Select(x => new DisgnosisAndPrescription()
            {
                PatientId = x.PatientId,
                PatientName = x.PatientName,
                symptoms = x.symptoms,
                PatientEmail = x.PatientEmail,
                Part = x.Part,
                diagnosis = x.diagnosis,
                Prescription = x.Prescription,

            }).ToListAsync();
            return records;
        }
    }
}
