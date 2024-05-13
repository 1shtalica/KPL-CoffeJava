namespace hospitalManagenetSystemAPI.Models
{
    public class Specialization
    {

        public int SpecializationId { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }


        public ICollection<Doctor>? Doctors { get; set; }
    }
}
