using ClincProject.Data.Entities;
using ClincProject.Data.Entities.Identities;
using ClincProject.Infrastructure.Data.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClincProject.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, Role,
        int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        #region Fileds
        public DbSet<Message> Messages { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientCase> PatientCases { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        public DbSet<StatusHistory> StatusHistories { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicDepartment> ClinicDepartments { get; set; }
        public DbSet<EmployeeSchedules> EmployeeSchedules { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        #region Constructors

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        #endregion

        #region Functions

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicConfig).Assembly);
        }
        #endregion



    }
}
