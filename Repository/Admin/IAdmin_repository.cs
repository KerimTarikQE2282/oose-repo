using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.Admin
{
    public interface IAdmin_repository
    {
        Task<AdminModel> AdminLogin(string Email, string _password);
    }
}
