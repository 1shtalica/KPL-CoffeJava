namespace hospitalManagenetSystemAPI.Models
{
    public class AppoimentPatient
    {
        public int AppoimentId { get; set; }
        public Appoiment Appoiment { get; set; }

        public int PatientId { get; set; }  
        public Patient Patient { get; set; }
    }
}
