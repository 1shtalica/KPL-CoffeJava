namespace hospitalManagenetSystemAPI.Models
{

    public enum DoctorSpecialization
    {
<<<<<<< Updated upstream
       
    
=======


>>>>>>> Stashed changes
        // Spesialisasi dalam bidang penyakit dalam
        InternalMedicine,

        // Spesialisasi dalam bidang bedah umum
        GeneralSurgery,

        // Spesialisasi dalam bidang kardiologi
        Cardiology,

        // Spesialisasi dalam bidang pediatri (kedokteran anak)
        Pediatrics,

        // Spesialisasi dalam bidang dermatologi
        Dermatology,

        // Spesialisasi dalam bidang ortopedi (kedokteran tulang)
        Orthopedics,

        // Spesialisasi dalam bidang neurologi
        Neurology,

        // Spesialisasi dalam bidang oftalmologi (kedokteran mata)
        Ophthalmology,

        // Spesialisasi dalam bidang ginekologi (kedokteran wanita)
        Gynecology,

        // Spesialisasi dalam bidang onkologi (kedokteran kanker)
        Oncology,

        // Spesialisasi dalam bidang urologi (kedokteran saluran kemih)
        Urology,

        // Spesialisasi dalam bidang anestesiologi
        Anesthesiology,

        // Spesialisasi dalam bidang radiologi
        Radiology,

        // Spesialisasi dalam bidang psikologi
        Psychiatry,

        // Spesialisasi dalam bidang endokrinologi
        Endocrinology,

<<<<<<< Updated upstream
       
=======

>>>>>>> Stashed changes
    }

    public class Doctor
    {
        public int DoctorId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string Address { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Salt { get; set; }
        public Specialization Specialization { get; set; }

        public ICollection<Appoiment>? Appoiments { get; set; }
        public ICollection<MedicalCheckUp>? MedicalCheckUps { get; set; }
    }
}
