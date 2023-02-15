using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.Representative
{
    public interface IRepresentative_repo
    {
        Task<List<RepresentativeModel>> GetAllRepresentativesAsync();
        Task<int> AddRepresentativesAsync(RepresentativeModel rep);
        Task<RepresentativeModel> RepresentativeLogin(string Email, string _password);
    }
}
