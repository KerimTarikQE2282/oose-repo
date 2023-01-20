﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class Hospitals_reposirory : IHospitalReporitory
    {
        private readonly ApplicationDbContext _context;
        public Hospitals_reposirory(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<HospitalsModel>> GetAllHospitalsAsync()
        {
            var records =await  _context.Hospitals.Select(x => new HospitalsModel()
            {

                HospitalId = x.HospitalId,
                HospitalName = x.HospitalName,
                HospitalRep = x.HospitalRep,
                HospitalKebele = x.HospitalKebele,
                HospitalKifleKetema = x.HospitalKifleKetema,
                HospitalWoreda = x.HospitalWoreda

            }). ToListAsync();
            return records;
        }
        public async Task<HospitalsModel> GetHospitalsAsync(int _HospitalId)
        {
            var records = await _context.Hospitals.Where(x => x.HospitalId == _HospitalId).Select(x => new HospitalsModel()
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
            var hospital = new Hospitals()
            {
               
                HospitalName = Hospital.HospitalName,
                HospitalRep = Hospital.HospitalRep,
                HospitalKebele = Hospital.HospitalKebele,
                HospitalKifleKetema = Hospital.HospitalKifleKetema,
                HospitalWoreda = Hospital.HospitalWoreda
            };
            _context.Hospitals.Add(hospital);
          await  _context.SaveChangesAsync();
            return hospital.HospitalId;


        }

    }
}