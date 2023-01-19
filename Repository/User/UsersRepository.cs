using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.User
{
    public class UsersRepository:IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SystemUsersModel>> GetAllUsersAsync()
        {
            var records = await _context.SystemUsers.Select(x => new SystemUsersModel()
            {

              UserId= x.UserId,
              firstName=x.firstName,
              middleName = x.middleName,
              lastName=x.lastName,
              email=x.email,
              password=x.password,
              phone=x.phone,
              role=x.role,
            
              

            }).ToListAsync();
            return records;
        }
        public async Task<int> AddUserAsync(SystemUsersModel User)
        {
            var user = new SystemUsers()
            {

                firstName = User.firstName,
                middleName = User.middleName,
                lastName = User.lastName,
                email = User.email,
                password = User.password,
                phone = User.phone,
                role=User.role,
                HospitalId=User.HospitalId  
    };
            _context.SystemUsers.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;


        }
    }
}
