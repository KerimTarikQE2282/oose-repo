using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.Vitals
{
    public class VitalsRepo:IVitalsRepo
    {
        public readonly ApplicationDbContext _vitals;
        public VitalsRepo(ApplicationDbContext vitals)
        {
            _vitals = vitals;
        }
        public async Task<int> AddVitals(VitalsModel vital)
        {


            var Vital = new Data.Vitals()
            {
                VitalId = vital.VitalId,
                PatientEmail = vital.PatientEmail,
                PatientName = vital.PatientName,
                bodyTempreature = vital.bodyTempreature,
                SystolicRate = vital.SystolicRate,
                diaStolicRate = vital.diaStolicRate,
                PulseRate = vital.PulseRate,
                RespatationRate = vital.RespatationRate,
                BlooddRate = vital.BlooddRate,
                date = DateTime.Now
            };
            _vitals.Vitals.Add(Vital);
            await _vitals.SaveChangesAsync();
            return vital.VitalId;
        }
        public async Task<List<VitalsModel>> PatientVitals(string email)
        {
            var records = await _vitals.Vitals.Where(x => x.PatientEmail == email).Select(x => new VitalsModel()
            {
                VitalId = x.VitalId,
                PatientEmail =x.PatientEmail,
                PatientName = x.PatientName,
                bodyTempreature =x.bodyTempreature,
                SystolicRate = x.SystolicRate,
                diaStolicRate = x.diaStolicRate,
                PulseRate =x.PulseRate,
                RespatationRate =x.RespatationRate,
                BlooddRate= x.BlooddRate,
               date=x.date

            }).ToListAsync();
            return records;
        }
    }
}
