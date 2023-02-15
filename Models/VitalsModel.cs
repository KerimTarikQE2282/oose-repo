using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class VitalsModel
    {
        [Key]
        public int VitalId { get; set; }
        public string PatientEmail { get; set; }
        public string PatientName { get; set;}
        public int  bodyTempreature { get; set; }
        public int SystolicRate { get; set; }
        public int diaStolicRate { get; set; }
        public int PulseRate { get; set; }
        public int RespatationRate { get; set; }
        public int BlooddRate { get; set; }
        public DateTime date { get; set; }
    }
}
