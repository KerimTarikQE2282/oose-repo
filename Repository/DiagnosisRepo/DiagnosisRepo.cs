using Microsoft.EntityFrameworkCore;
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
                diagnosis = diagnosis.diagnosis,
                Prescription= diagnosis.Prescription,
            };
           Context.DisgnosisAndPrescription.Add(Diagnosis);
            await Context.SaveChangesAsync();
            return Diagnosis.DiagnosisId;
        }
    }
}
