using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.Hospital
{
    public class Hospitals_reposirory : IHospitalReporitory
    {
        private readonly ApplicationDbContext _context;
        public Hospitals_reposirory(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<HospitalsModel>> GetAllHospitalsAsync()
        {
            var records = await _context.Hospitals.Select(x => new HospitalsModel()
            {

                HospitalId = x.HospitalId,
                HospitalName = x.HospitalName,
                HospitalRep = x.HospitalRep,
                HospitalKebele = x.HospitalKebele,
                HospitalKifleKetema = x.HospitalKifleKetema,
                HospitalWoreda = x.HospitalWoreda

            }).ToListAsync();
            return records;
        }
        public async Task<HospitalsModel> GetHospitalsAsync(string _HospitalName)
        {
            var records = await _context.Hospitals.Where(x => x.HospitalName == _HospitalName).Select(x => new HospitalsModel()
            {

                HospitalId = x.HospitalId,
                HospitalName = x.HospitalName,
                HospitalRep = x.HospitalRep,
                HospitalKebele = x.HospitalKebele,
                HospitalKifleKetema = x.HospitalKifleKetema,
                HospitalWoreda = x.HospitalWoreda

            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddHospitalsAsync(HospitalsModel Hospital)
        {

            var records = await _context.Hospitals.Where(x => x.HospitalName == Hospital.HospitalName).Select(x => new HospitalsModel()
            {

                HospitalId = x.HospitalId,
                HospitalName = x.HospitalName,
                HospitalRep = x.HospitalRep,
                HospitalKebele = x.HospitalKebele,
                HospitalKifleKetema = x.HospitalKifleKetema,
                HospitalWoreda = x.HospitalWoreda

            }).FirstOrDefaultAsync();
            if (records != null)
            {
                return 0;
            }

            var hospital = new Hospitals()
                {

                    HospitalName = Hospital.HospitalName,
                    HospitalRep = Hospital.HospitalRep,
                    HospitalKebele = Hospital.HospitalKebele,
                    HospitalKifleKetema = Hospital.HospitalKifleKetema,
                    HospitalWoreda = Hospital.HospitalWoreda
                };
                _context.Hospitals.Add(hospital);
                await _context.SaveChangesAsync();
                return hospital.HospitalId;
            
            


               
            

        }
        public async Task <int> UpdateHospital(string _HospitalName,HospitalsModel hospitalModel)
        {
            var Hospital = await _context.Hospitals.Where(x => x.HospitalName == _HospitalName).Select(x => new HospitalsModel()
            {

                HospitalId = x.HospitalId,
                HospitalName = x.HospitalName,
                HospitalRep = x.HospitalRep,
                HospitalKebele = x.HospitalKebele,
                HospitalKifleKetema = x.HospitalKifleKetema,
                HospitalWoreda = x.HospitalWoreda

            }).FirstOrDefaultAsync();
            if(Hospital !=null)
            {
                Hospital.HospitalName = hospitalModel.HospitalName;
                Hospital.HospitalRep = hospitalModel.HospitalRep;
                Hospital.HospitalKebele = hospitalModel.HospitalKebele;
                Hospital.HospitalKifleKetema = hospitalModel.HospitalKifleKetema;
                Hospital.HospitalWoreda = hospitalModel.HospitalWoreda;

              var val= await _context.SaveChangesAsync();
                return val;
            }
            else
            {
                return 0;
            }
           
        }

    }
}
