﻿namespace hospitalManagenetSystemAPI.Models
{
    public class Admin
    {
        public int AdminId { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
