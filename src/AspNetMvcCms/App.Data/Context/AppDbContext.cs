using Cms.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Cms.Data.Context
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
        public DbSet<NavbarEntity> Navbars { get; set; }

        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BlogEntity> Blogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorEntity>().HasData(
               new DoctorEntity { Id = 1, Name = "Ali Rıza ", Surname = "Canbulan", Email = "aliriza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 1, ResimDosyaAdi = "team/1.jpg" },
               new DoctorEntity { Id = 2, Name = "xxx ", Surname = "Canbulan", Email = "alirıza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 2, ResimDosyaAdi = "team/2.jpg" },
               new DoctorEntity { Id = 3, Name = "yyyy ", Surname = "Canbulan", Email = "alirıza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 3, ResimDosyaAdi = "team/3.jpg" },
               new DoctorEntity { Id = 4, Name = "bbb ", Surname = "Canbulan", Email = "alirıza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 4, ResimDosyaAdi = "team/4.jpg" },
               new DoctorEntity { Id = 5, Name = "nnnn", Surname = "Canbulan", Email = "alirıza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 5, ResimDosyaAdi = "team/1.jpg" },
               new DoctorEntity { Id = 6, Name = "yyyy", Surname = "Canbulan", Email = "alirıza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 6, ResimDosyaAdi = "team/2.jpg" },
               new DoctorEntity { Id = 7, Name = "Ali  ", Surname = "Canbulan", Email = "alirıza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 4, ResimDosyaAdi = "team/3.jpg" }
               );

            modelBuilder.Entity<DepartmentEntity>().HasData(
               new DepartmentEntity { Id = 1, Name = "Opthomology ", Description = "Saepe nulla praesentium eaque omnis perferendis a doloremque." },
               new DepartmentEntity { Id = 2, Name = "Cardiology", Description = "Saepe nulla praesentium eaque omnis perferendis a doloremque." },
               new DepartmentEntity { Id = 3, Name = "Dental Care", Description = "Saepe nulla praesentium eaque omnis perferendis a doloremque." },
               new DepartmentEntity { Id = 4, Name = "Child Care", Description = "Saepe nulla praesentium eaque omnis perferendis a doloremque." },
               new DepartmentEntity { Id = 5, Name = "Pulmology", Description = "Saepe nulla praesentium eaque omnis perferendis a doloremque." },
               new DepartmentEntity { Id = 6, Name = "Gynecology", Description = "Saepe nulla praesentium eaque omnis perferendis a doloremque." }
            );
            modelBuilder.Entity<BlogEntity>().HasData(
            new BlogEntity { Id = 1, Title = "Healthy environment to care with modern equipment ", Description = "Non illo quas blanditiis repellendus laboriosam minima animi. Consectetur accusantium pariatur repudiandae!\r\n\r\nLorem ipsum dolor sit amet, consectetur adipisicing elit. Possimus natus, consectetur? Illum libero vel nihil nisi quae, voluptatem, sapiente necessitatibus distinctio voluptates, iusto qui. Laboriosam autem, nam voluptate in beatae. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae iure officia nihil nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore.", BlogCategoryId =1, ResimDosyaAdi= "blog/blog-1.jpg" },
            new BlogEntity { Id = 2, Title = "All test cost 25% in always in our laboratory", Description = "Non illo quas blanditiis repellendus laboriosam minima animi. Consectetur accusantium pariatur repudiandae!\r\n\r\nLorem ipsum dolor sit amet, consectetur adipisicing elit. Possimus natus, consectetur? Illum libero vel nihil nisi quae, voluptatem, sapiente necessitatibus distinctio voluptates, iusto qui. Laboriosam autem, nam voluptate in beatae. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae iure officia nihil nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore.", BlogCategoryId =2, ResimDosyaAdi= "blog/blog-2.jpg" },
             new BlogEntity { Id = 3, Title = "Get Free consulation from our special surgeon and doctors", Description = "Non illo quas blanditiis repellendus laboriosam minima animi. Consectetur accusantium pariatur repudiandae!\r\n\r\nLorem ipsum dolor sit amet, consectetur adipisicing elit. Possimus natus, consectetur? Illum libero vel nihil nisi quae, voluptatem, sapiente necessitatibus distinctio voluptates, iusto qui. Laboriosam autem, nam voluptate in beatae. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae iure officia nihil nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore.", BlogCategoryId =3, ResimDosyaAdi= "blog/blog-4.jpg" }
            

             );

            modelBuilder.Entity<BlogCategoryEntity>().HasData(
           new BlogCategoryEntity { Id = 1, Title = "Medicine" },
           new BlogCategoryEntity { Id = 2, Title = "Equipments" },
           new BlogCategoryEntity { Id = 3, Title = "Heart" },
            new BlogCategoryEntity { Id = 4, Title = "Free counselling" },
           new BlogCategoryEntity { Id = 5, Title = "Lab test " }

           );

            modelBuilder.Entity<PatientEntity>().HasData(
          new PatientEntity
          {
              Id = 1,
              Name = "Ali Rızaxx ",
              Surname = "Canbulanxx",
              Email = "aliriza@canbulanxx.com",
              Phone = "05554443311",
              Password = "12345"



          },
           
          new PatientEntity
          {
              Id = 2,
              Name = "mehmet ",
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
                   Email = "aliriza@canbulanxxyy.com",
                   Phone = "05554442211",
                   Password = "12345678"

               }
                );
            modelBuilder.Entity<NavbarEntity>().HasData(
            new NavbarEntity() { Id = 1, Name = "Home" },
            new NavbarEntity() { Id = 2, Name = "About" },
            new NavbarEntity() { Id = 3, Name = "Services" },
            new NavbarEntity() { Id = 4, Name = "Departments" },
            new NavbarEntity() { Id = 5, Name = "Doctors" },
            new NavbarEntity() { Id = 6, Name = "Blog" },
            new NavbarEntity() { Id = 7, Name = "Contact" }
                 );
            modelBuilder.Entity<DoctorCategoryEntity>().HasData(
            new DoctorCategoryEntity() { Id = 1, Name = "Cardiology" },
            new DoctorCategoryEntity() { Id = 2, Name = "Dental" },
            new DoctorCategoryEntity() { Id = 3, Name = "Neurology" },
            new DoctorCategoryEntity() { Id = 4, Name = "Medicine" },
            new DoctorCategoryEntity() { Id = 5, Name = "Pediatric" },
            new DoctorCategoryEntity() { Id = 6, Name = "Traumatology" }

                 );
          

            base.OnModelCreating(modelBuilder);
        }

    }
}
