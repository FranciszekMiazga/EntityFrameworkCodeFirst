using EFWebApplicationCodeFirst.EfConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFWebApplicationCodeFirst.Models
{
    public class MainDbContext : DbContext
    {
        /*IConfiguration _configuration;
        public MainDbContext(IConfiguration configuration)
        {
            _configuration = configuration;//_configuration.GetConnectionString("ProductionDb")
        }*/
        public MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20659;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MedicamentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionEntityTypeConfiguration());

        }
    }
}
