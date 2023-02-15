using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.Admin
{
    public class Admin_repository:IAdmin_repository
    {
        private readonly ApplicationDbContext _context;
        public Admin_repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminModel> AdminLogin(string Email,string _password)
        {
            var records = await _context.Admin.Where(x => x.AdminEmail == Email && x.passowrd == _password).Select(x => new AdminModel()
            {

                AdminId = x.AdminId,
                AdminFisrtName= x.AdminFisrtName,
                Role=x.Role,
              
             

            }).FirstOrDefaultAsync();
            return records;
        }
    }
}
