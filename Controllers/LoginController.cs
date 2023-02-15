using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository.Admin;
using WebApplication1.Repository.Hospital;
using WebApplication1.Repository.Representative;
using WebApplication1.Repository.User;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
      
            public readonly IAdmin_repository _hr;
        public readonly IRepresentative_repo _Rep;
        public readonly IUsersRepository _User;
        public LoginController(IAdmin_repository hr, IRepresentative_repo Rep, IUsersRepository User)
            {
                _hr = hr;
            _Rep = Rep;
            _User= User;
        }
             [HttpPost("")]
            public async Task<IActionResult> AdminLogin([FromBody] Login login)
        {
            var Admin = await _hr.AdminLogin(login.Email, login.Password);
            if (Admin != null)
            {
              
                return Ok(Admin);
            }
            var Repr = await _Rep.RepresentativeLogin(login.Email, login.Password);
            if (Repr != null)
            {

                return Ok(Repr);
            }
            var Usr = await _User.UserLogin(login.Email, login.Password);
            if (Usr != null)
            {

                return Ok(Usr);
            }
            return NotFound();

        }
    }
    }

