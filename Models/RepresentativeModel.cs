namespace WebApplication1.Models
{
    public class RepresentativeModel
    {
        public  int RepresentativeId { get; set; }
        public string FirstName { get; set; }
        public string middleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string  region{ get; set; }

        public string kebele { get; set; }
        public string kifleketema { get; set; }
        public string woreda { get; set; }
        public int HospitalId { get; set; }
        public string Password { get; set; }

    }
}
