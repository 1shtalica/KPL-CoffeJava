using hospitalManagementSystemAPI.Models;
using hospitalManagenetSystemAPI.Models;

namespace hospitalManagenetSystemAPI.NewFolder
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly BirthDate { get; set; }

       
    }
}
