using Microsoft.EntityFrameworkCore;

namespace hospitalManagenetSystemAPI.Models
{

    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Canceled,
        
    }
    public class Appoiment
    {
        //pk
        public int AppoimentId { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public AppointmentStatus Status { get; set; }
        public bool IsCompleted { get; set; }
        public int Sapacity { get; set; }


       
        public Room Room { get; set; }
        public ICollection<Patient>? Patients { get; set; }

   
        public Doctor Doctor { get; set; }


        
    }
}
