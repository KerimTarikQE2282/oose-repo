using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.Hospital
{
    public interface IHospitalReporitory
    {
        Task<List<HospitalsModel>> GetAllHospitalsAsync();
        Task<HospitalsModel> GetHospitalsAsync(string _HospitalName);
        Task<int> AddHospitalsAsync(HospitalsModel Hospital);
    }
}
