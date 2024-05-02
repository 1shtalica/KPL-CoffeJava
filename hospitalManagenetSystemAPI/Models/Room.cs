namespace hospitalManagenetSystemAPI.Models
{
    public class Room
    {
        
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int RoomFloor { get; set; }  
        public int RoomNumber { get; set; }
        public ICollection<Appoiment>? Appoiments { get; set; }
    }
}
