using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class HospitalsModel
    {
        [Key]
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalRep { get; set; }
        public string HospitalKebele { get; set; }
        public string HospitalKifleKetema { get; set; }
        public string HospitalWoreda { get; set; }
    }
}
