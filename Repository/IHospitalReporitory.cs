using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IHospitalReporitory
    {
        Task<List<HospitalsModel>> GetAllHospitalsAsync();
        Task<HospitalsModel> GetHospitalsAsync(int _HospitalId);
        Task<int> AddHospitalsAsync(HospitalsModel Hospital);
    }
}
