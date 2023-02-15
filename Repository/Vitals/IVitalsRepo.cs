using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.Vitals
{
    public interface IVitalsRepo
    {
        Task<int> AddVitals(VitalsModel vital);
        Task<List<VitalsModel>> PatientVitals(string email);
    }
}
