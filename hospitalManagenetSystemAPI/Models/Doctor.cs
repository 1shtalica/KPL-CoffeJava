namespace hospitalManagenetSystemAPI.Models
{

    

    public class Doctor
    {
        public int DoctorId { get; set; }
        public string firstName { get; set; }   
        public string lastName { get; set; }

        public string Address { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Salt { get; set; }
        public Specialization Specialization { get; set; }

        public ICollection<Appoiment>? Appoiments { get; set; }
        public ICollection<MedicalCheckUp>? MedicalCheckUps { get; set; }
    }
}
