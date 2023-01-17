using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PatientsModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string Kebele { get; set; }
        public string kifleketema { get; set; }
        public string wereda { get; set; }
        public string DOB { get; set; }
        
        public string phoneNumber { get; set; }
        public string emergencyPhone { get; set; }
    }
}

