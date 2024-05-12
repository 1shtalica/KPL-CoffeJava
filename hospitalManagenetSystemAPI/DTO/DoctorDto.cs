namespace hospitalManagenetSystemAPI.DTO
{
    public class DoctorDto
    {
 
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string Address { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
    }
}
