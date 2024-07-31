using EFTask2Hosbital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask2Hosbital
{
    internal class AppContext : DbContext
    {
        private static readonly string serverName = @"MAKKAWY\SQLEXPRESS";
        private static readonly string databaseName = "EFTask2Hosbital";
        private static readonly string username = "makkawy";
        private static readonly string password = "123456";

        string connectionString = $"Server={serverName};Database={databaseName};User Id={username};Password={password};Trust Server Certificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>

            optionsBuilder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Patient Validation*/
            modelBuilder.Entity<Patient>()
                .Property(x => x.PatientName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Patient>().Property(x => x.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();

            /*Doctor Validation*/
            modelBuilder.Entity<Doctor>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Doctor>()
                .Property(x => x.YearsOfExperince)
                .IsRequired();
            modelBuilder.Entity<Doctor>()
                .Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            /*Department Validation*/
            modelBuilder.Entity<Department>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Department>()
                .Property(x => x.Location)
                .IsRequired();

            /*Appointment Validation*/
            modelBuilder.Entity<Appointment>()
                .Property(x => x.AppoinmentDate)
                .IsRequired();
            modelBuilder.Entity<Appointment>()
                .Property(x => x.Reason)
                .HasMaxLength(500);
            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientDoctor> PatientDoctor { get; set; }

        
        
    }
}
