namespace hospitalManagenetSystemAPI.Models
{
    public class Patient
    {
        public enum GenderType
        {
            Male,
            Female,

        }

        public enum BloodType
        {
            A,
            B,
            AB,
            O
        }
        //pk
        public int PatientId { get; set; }  
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Address { get; set;}
        public string PhoneNumber { get; set; }
        public string Email { get; set;}
        public string Password { get; set; }
        public DateOnly BirthDate { get; set;}
        public GenderType Gender { get; set; }
        public BloodType Blood { get; }
        public ICollection<Appoiment>? Appoiments { get; set; }
        public ICollection<MedicalCheckUp>? medicalCheckUps { get; set; }   
    }
}
