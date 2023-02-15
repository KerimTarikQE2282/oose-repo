using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Repository.User
{
    public interface IUsersRepository
    {
        Task<List<SystemUsersModel>> GetAllUsersAsync();
        Task<int> AddUserAsync(SystemUsersModel User);
        Task<SystemUsersModel> UserLogin(string Email, string _password);
    }
}
