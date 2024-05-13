using hospitalManagenetSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace hospitalManagementSystemAPI.Models
{
    public class Gender
    {
        [Key]
        [Required]
        public string Name { get; set; }

        public ICollection<Patient> patients { get; set; }

    }
}