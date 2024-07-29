using Dentist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=monsterhuma268\\SQLEXPRESS; initial Catalog=DentistDb; integrated Security=true;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Server=MONSTERHUMA268;Database=DentistDb;User=sa;Password=123456tunc; Trusted_Connection = True; TrustServerCertificate = True; MultipleActiveResultSets = True; Integrated security = false; Connection Timeout = 0;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<CategoryCard> CategoryCards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<ServiceCard> ServiceCards { get; set; }
        public DbSet<ServicePromotion> ServicePromotions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderCard> SliderCards { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ProcedureLog> ProcedureLogs { get; set; }

    }
}
