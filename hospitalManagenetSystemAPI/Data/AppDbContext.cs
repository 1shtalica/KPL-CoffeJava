using hospitalManagementSystemAPI.Models;
using hospitalManagenetSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace hospitalManagenetSystemAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appoiment> Appoiments { get; set; }
        public DbSet<AppoimentPatient> AppoimentPatients { get; set; }

        public DbSet<Doctor> doctors { get; set; }
        public DbSet<MedicalCheckUp> medicalCheckUps { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Room> rooms { get; set; }

        public DbSet<Gender> genders { get; set; }
        public DbSet<BloodType> bloodTypes { get; set; }
        public DbSet<Specialization> specializations { get; set; }




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

<<<<<<< Updated upstream
           
=======


>>>>>>> Stashed changes


           
        }

    }
}
