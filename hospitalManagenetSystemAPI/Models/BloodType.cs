using System.ComponentModel.DataAnnotations;

namespace hospitalManagenetSystemAPI.Models
{
    public class BloodType
    {
        [Key]
        [Required]
        public string bloodType { get; set; }
        public ICollection<Patient> patients { get; set; }

    }
}
