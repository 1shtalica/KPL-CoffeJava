using hospitalManagementSystemAPI.Models;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace hospitalManagenetSystemAPI.Models
{
    public class Patient
    {
       
        //pk
        public int PatientId { get; set; }  
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Address { get; set;}
        public string PhoneNumber { get; set; }
        public string Email { get; set;}
        public string Password { get; set; }
        public DateOnly BirthDate { get; set;}      
        public Gender Gender { get; set; }
        public BloodType BloodType { get; set; }
        public string Salt { get; set; }
        public ICollection<Appoiment>? Appoiments { get; set; }
       
        public ICollection<MedicalCheckUp>? medicalCheckUps { get; set; }   
    }
}
