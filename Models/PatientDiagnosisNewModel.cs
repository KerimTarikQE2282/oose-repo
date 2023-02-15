using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PatientDiagnosisNewModel
    {
        [Key]
        public int DiagnosisId { get; set; }
        //public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string  symptoms { get; set; }
        public string Part { get; set; }
        public string  diagnosis{ get; set; }
        public string Prescription { get; set; }
    }
}
