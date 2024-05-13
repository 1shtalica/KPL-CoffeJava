namespace hospitalManagenetSystemAPI.Models
{
    public class MedicalCheckUp
    {
        public int MedicalChekUpId { get; set; }
        public DateOnly date { get; set; }
        public string NoteMedicalChekup { get; set; }

        public string Result { get; set; }


        public Doctor Doctor { get; set; }


        public Patient Patient { get; set; }

    }
}
