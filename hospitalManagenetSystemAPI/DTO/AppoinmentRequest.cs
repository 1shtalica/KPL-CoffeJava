using hospitalManagenetSystemAPI.Models;

namespace hospitalManagenetSystemAPI.DTO
{
    public class AppoinmentRequest
    {
        public int AppoimentId { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public AppointmentStatus Status { get; set; }
        public int Sapacity { get; set; }
        public bool IsComplete { get; set; }
        public DateOnly date { get; set; }
    }
}
