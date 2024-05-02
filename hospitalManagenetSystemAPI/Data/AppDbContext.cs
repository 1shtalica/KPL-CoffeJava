using hospitalManagenetSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace hospitalManagenetSystemAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appoiment> Appoiments { get; set; }
        public DbSet<AppoimentPatient> AppoimentPatients { get; set; }

        public DbSet<Doctor> doctors { get; set; }
        public DbSet<MedicalCheckUp> medicalCheckUps { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Room> rooms { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Appoiment>()
                .HasMany(a => a.Patients)
                .WithMany(p => p.Appoiments)
                .UsingEntity<AppoimentPatient>(
                    j => j
                        .HasOne(ap => ap.Patient)
                        .WithMany()
                        .HasForeignKey(ap => ap.PatientId),
                    j => j
                        .HasOne(ap => ap.Appoiment)
                        .WithMany()
                        .HasForeignKey(ap => ap.AppoimentId),
                    j =>
                    {
                        j.HasKey(ap => new { ap.AppoimentId, ap.PatientId });
                    });

            modelBuilder.Entity<Doctor>()
               .HasMany(d => d.Appoiments) // Doctor memiliki banyak Appoiments
               .WithOne(a => a.Doctor) // Appoiment terkait dengan satu Doctor
               .HasForeignKey(a => a.DoctorId); // Kunci asing di Appoiment yang mengacu pada Doctor

            // Konfigurasi relasi one-to-many antara Doctor dan MedicalCheckUp
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.MedicalCheckUps) // Doctor memiliki banyak MedicalCheckUps
                .WithOne(m => m.Doctor) // MedicalCheckUp terkait dengan satu Doctor
                .HasForeignKey(m => m.DoctorId);


            modelBuilder.Entity<Appoiment>()
               .HasOne(a => a.Room) // Appoiment terkait dengan satu Room
               .WithMany(r => r.Appoiments) // Room memiliki banyak Appoiment
               .HasForeignKey(a => a.RoomId);

            modelBuilder.Entity<Patient>()
               .HasMany(p => p.medicalCheckUps) // Patient memiliki banyak MedicalCheckUps
               .WithOne(m => m.Patient) // MedicalCheckUp terkait dengan satu Patient
               .HasForeignKey(m => m.PatientId);


            modelBuilder.Entity<Admin>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Admin>()
                .HasIndex(a => a.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Patient>()
               .HasIndex(a => a.Email)
               .IsUnique();

            modelBuilder.Entity<Patient>()
                .HasIndex(a => a.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Doctor>()
               .HasIndex(a => a.Email)
               .IsUnique();

            modelBuilder.Entity<Doctor>()
                .HasIndex(a => a.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<MedicalCheckUp>().HasKey(a => a.MedicalChekUpId);
        }

    }
}
