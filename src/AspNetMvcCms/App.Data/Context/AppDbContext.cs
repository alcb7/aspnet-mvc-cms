using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<DoctorCommentEntity> DoctorComments { get; set; }
        public DbSet<BlogCategoryEntity> BlogCategories { get; set; }
        public DbSet<ServiceBlogEntity> ServiceBlogs { get; set; }
        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<DoctorCategoryEntity> DoctorCategories { get; set; }
        public DbSet<PopulerPostEntity> PopulerPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorEntity>().HasData(
               new DoctorEntity
               {
                   Id = 1,
                   Name = "Ali Rıza ",
                   Surname = "Canbulan",
                   Email = "alirıza@canbulan.com",
                   Phone = "05554443322",
                   Password = "1234"

               }
               );

            modelBuilder.Entity<PatientEntity>().HasData(
          new PatientEntity
          {
              Id = 1,
              Name = "Ali Rızaxx ",
              Surname = "Canbulanxx",
              Email = "alirıza@canbulanxx.com",
              Phone = "05554443311",
              Password = "12345"

          }
           );

            modelBuilder.Entity<AdminEntity>().HasData(
               new AdminEntity
               {
                   Id = 1,
                   Name = "Ali Rızaxxyy ",
                   Surname = "Canbulanxxyy",
                   Email = "alirıza@canbulanxxyy.com",
                   Phone = "05554442211",
                   Password = "123456"

               }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
