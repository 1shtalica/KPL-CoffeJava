﻿namespace hospitalManagementSystemAPI.Models
{
    public class PatientUpdateDto
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }

     
    }
}
