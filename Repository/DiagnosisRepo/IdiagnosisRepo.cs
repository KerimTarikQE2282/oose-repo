using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Repository.DiagnosisRepo
{
    public interface IdiagnosisRepo
    {
        Task<int> AddDiagnosis(DisgnosisAndPrescription diagnosis);
        Task<List<DisgnosisAndPrescription>> SearchDiagnosticAndPrescription(string Email);
    }
}
