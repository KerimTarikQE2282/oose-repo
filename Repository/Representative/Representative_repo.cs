using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.Representative
{
    public class Representative_repo : IRepresentative_repo
    {
        private readonly ApplicationDbContext _context;
        public Representative_repo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<RepresentativeModel>> GetAllRepresentativesAsync()
        {
            var records = await _context.Representatives.Select(x => new RepresentativeModel()
            {

                RepresentativeId = x.RepresentativeId,
                FirstName = x.FirstName,
                middleName = x.middleName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                region = x.region,
                kebele = x.kebele,
                kifleketema = x.kifleketema,
                woreda = x.woreda,
                HospitalId = x.HospitalId,
                Password = x.Password,


            }).ToListAsync();
            return records;
        }
        public async Task<int> AddRepresentativesAsync(RepresentativeModel rep)
        {
            var Rep = new Representatives()
            {

                FirstName = rep.FirstName,
                middleName = rep.middleName,
                LastName = rep.LastName,
                Email = rep.Email,
                PhoneNumber = rep.PhoneNumber,
                region = rep.region,
                kebele = rep.kebele,
                kifleketema = rep.kifleketema,
                woreda = rep.woreda,
                HospitalId = rep.HospitalId,
                Password = rep.Password,
            };
            _context.Representatives.Add(Rep);
            await _context.SaveChangesAsync();
            return Rep.RepresentativeId;


        }



    }
}
    
