using hospitalManagenetSystemAPI.Models;

namespace hospitalManagenetSystemAPI.DTO
{
    public class AppoinmentEdit
    {
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public AppointmentStatus Status { get; set; }
        public bool IsCompleted { get; set; }
        public int Sapacity { get; set; }

        public DateOnly date { get; set; }
   
    }
}
