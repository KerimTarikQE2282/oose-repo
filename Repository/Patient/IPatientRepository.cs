using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.Patient
{
    public interface IPatientRepository
    {
        Task<List<PatientsModel>> GetAllPatientsAsync();
        Task<PatientsModel> Search(string phoneNumber);
        Task<string> RegisterPatientAsync(PatientsModel Patient);
    }
}