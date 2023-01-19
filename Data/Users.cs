using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class Users
    {
        [Key]
        public int   UserId{ get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
        public int HospitalId { get; set; }
        
    }
}
