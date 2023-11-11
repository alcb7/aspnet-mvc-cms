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
        public DbSet<FileEntity> Files { get; set; }
		public DbSet<PatientCommentEntity> PatientComments { get; set; }




		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorEntity>().HasData(
               new DoctorEntity { Id = 1, Name = "Ali Rıza ", Surname = "Canbulan", Email = "aliriza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 1, ResimDosyaAdi = "doctor.1.jpg", Cv="fdsjfıldjsfldjflıdjsfıjldsjfdsı" ,NavbarId=5},
               new DoctorEntity { Id = 2, Name = "Mehmet ", Surname = "Kirisoglu", Email = "alirıza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 2, ResimDosyaAdi = "doctor.2.jpg", Cv = "fdsjfıldjsfldjflıdjsfıjldsjfdsı", NavbarId = 5 },
               new DoctorEntity { Id = 3, Name = "Ahmet ", Surname = "Canbulan", Email = "mehmet@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 3, ResimDosyaAdi = "doctor.3.jpg", Cv = "fdsjfıldjsfldjflıdjsfıjldsjfdsı", NavbarId = 5 },
               new DoctorEntity { Id = 4, Name = "Huseyin ", Surname = "Canbulan", Email = "ali@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 4, ResimDosyaAdi = "doctor.4.jpg", Cv = "fdsjfıldjsfldjflıdjsfıjldsjfdsı", NavbarId = 5 },
               new DoctorEntity { Id = 5, Name = "Kerem", Surname = "Canbulan", Email = "riza@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 5, ResimDosyaAdi = "doctor.1.jpg", Cv = "fdsjfıldjsfldjflıdjsfıjldsjfdsı", NavbarId = 5 },
               new DoctorEntity { Id = 6, Name = "Kum", Surname = "Canbulan", Email = "kum@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 6, ResimDosyaAdi = "doctor.1.jpg", Cv = "fdsjfıldjsfldjflıdjsfıjldsjfdsı", NavbarId = 5 },
               new DoctorEntity { Id = 7, Name = "Gokhan  ", Surname = "Canbulan", Email = "gokhan@canbulan.com", Phone = "05554443322", Password = "1234", CategoryId = 4, ResimDosyaAdi = "doctor.1.jpg", Cv = "fdsjfıldjsfldjflıdjsfıjldsjfdsı", NavbarId = 5 }
               );

            modelBuilder.Entity<DepartmentEntity>().HasData(
               new DepartmentEntity { Id = 1, Name = "Opthomology ", Description = "Optometry is a branch of healthcare that focuses on the examination, diagnosis, and treatment of various eye conditions and visual system disorders. Optometrists, also known as doctors of optometry, play a crucial role in preserving and enhancing one of our most precious senses – vision..", NavbarId= 4 , ResimDosyaAdi = "dep-1.jpg" },
               new DepartmentEntity { Id = 2, Name = "Cardiology", Description = "Cardiology, a field integral to the realm of healthcare, focuses on the intricate system that sustains life - the cardiovascular system. As the guardians of heart health, cardiologists play a pivotal role in diagnosing, treating, and preventing a myriad of cardiovascular conditions, ensuring that the human heart continues to beat steadily and robustly..", NavbarId = 4, ResimDosyaAdi = "dep-2.jpg" },
               new DepartmentEntity { Id = 3, Name = "Dental Care", Description = "Dental care, a fundamental aspect of overall health and well-being, is the discipline dedicated to maintaining the health of our teeth, gums, and oral cavity. Dentistry goes beyond merely addressing dental issues; it is a holistic approach to ensuring vibrant smiles and promoting lifelong oral health.", NavbarId = 4, ResimDosyaAdi = "dep-3.jpg" },
               new DepartmentEntity { Id = 4, Name = "Child Care", Description = "Child care is a vital aspect of early childhood development that extends far beyond meeting basic needs. It encompasses a holistic approach to creating a nurturing environment where children can thrive emotionally, socially, and intellectually. Effective child care lays the foundation for healthy growth, lifelong learning, and the development of essential life skills.", NavbarId = 4, ResimDosyaAdi = "dep-4.jpg" },
               new DepartmentEntity { Id = 5, Name = "Pulmology", Description = "Pulmonology, a specialized branch of medicine, is dedicated to the study and treatment of respiratory diseases and disorders. From the intricacies of the respiratory system to the complexities of lung conditions, pulmonologists play a pivotal role in ensuring optimal respiratory health and improving the quality of life for individuals facing pulmonary challenges.", NavbarId = 4, ResimDosyaAdi = "dep-5.jpg" },

			   new DepartmentEntity { Id = 6, Name = "Gynecology", Description = "Gynecology, a specialized branch of medicine, focuses on the health and well-being of the female reproductive system. Beyond the clinical aspects, gynecologists serve as advocates for women's health, addressing a spectrum of medical, emotional, and preventive care needs unique to women throughout their lives..", NavbarId = 4, ResimDosyaAdi = "dep-6.jpg" }
			);
            modelBuilder.Entity<BlogEntity>().HasData(
            new BlogEntity { Id = 1, Title = "Healthy environment to care with modern equipment ", Description = "In the ever-evolving landscape of healthcare, the convergence of a healthy environment and cutting-edge technology is reshaping the way we approach patient care. From the soothing ambiance of healthcare spaces to the integration of state-of-the-art equipment, the synergy between environment and technology plays a pivotal role in fostering optimal patient outcomes.\r\n\r\nThe Healing Power of Environment:\r\nComforting Atmosphere:\r\nCreating a healthcare environment that promotes tranquility and comfort is fundamental to patient well-being. Soft lighting, calming colors, and well-designed spaces contribute to reducing stress and anxiety levels.\r\n\r\nNature Integration:\r\nIncorporating natural elements, such as indoor plants or views of green spaces, brings a touch of nature into healthcare settings. Studies suggest that exposure to nature has positive effects on patient recovery and overall satisfaction.\r\n\r\nPersonalized Spaces:\r\nTailoring care environments to individual preferences fosters a sense of personalization. Patient rooms equipped with adjustable lighting, temperature controls, and entertainment options empower patients to have greater control over their surroundings.\r\n\r\nThe Role of Modern Equipment:\r\nPrecision Diagnostics:\r\nState-of-the-art diagnostic equipment enhances the accuracy and efficiency of medical assessments. From advanced imaging technologies to high-tech laboratory equipment, modern tools empower healthcare professionals to diagnose and treat conditions with precision.\r\n\r\nMinimally Invasive Procedures:\r\nCutting-edge equipment enables the performance of minimally invasive procedures, reducing patient discomfort, and expediting recovery times. Technologies like robotic-assisted surgery offer unprecedented precision and control in surgical interventions.\r\n\r\nTelemedicine Integration:\r\nThe integration of telemedicine technologies expands access to care beyond traditional boundaries. Patients can connect with healthcare providers remotely, fostering convenience and ensuring timely medical consultations.\r\n\r\nThe Synergy of Environment and Technology:\r\nEfficient Workflows:\r\nWell-designed healthcare environments, coupled with modern equipment, contribute to streamlined workflows for healthcare professionals. Efficient spaces equipped with advanced technology facilitate seamless communication and collaboration among care teams.\r\n\r\nPatient-Centered Care:\r\nThe intersection of a healing environment and modern equipment places the focus squarely on patient-centered care. The combination of compassionate spaces and cutting-edge tools ensures that patients receive not only top-notch medical care but also a positive overall experience.\r\n\r\nInnovation for the Future:\r\nThe ongoing integration of environmental design principles and technological advancements signals a commitment to innovation in healthcare. This forward-looking approach sets the stage for continued improvements in patient outcomes and the overall healthcare experience.\r\n\r\nConclusion:\r\nCreating a healthy environment for care involves a delicate dance between the soothing elements of design and the precision of modern equipment. As healthcare continues to embrace both aspects, patients can expect not only advanced medical treatments but also an environment that supports their well-being and contributes to a positive healing journey. The marriage of a healing environment with cutting-edge technology heralds a new era in patient-centered, innovative healthcare.", BlogCategoryId =1, ResimDosyaAdi= "blog-1.jpg" },
            new BlogEntity { Id = 2, Title = "All test cost 25% in always in our laboratory", Description = "Introduction:\r\n\r\nAccess to affordable healthcare is a cornerstone of a thriving community, and at [Your Laboratory Name], we are committed to revolutionizing the healthcare landscape. Our innovative approach, offering a flat rate where all test costs are consistently set at 25%, aims to break down financial barriers and make comprehensive health diagnostics accessible to everyone.\r\n\r\nThe All-Test Cost Model Explained:\r\nSimplicity in Pricing:\r\nTraditional healthcare pricing models often lead to confusion and unexpected costs. Our all-test cost model simplifies the process by offering a straightforward pricing structure. Patients can rest assured that any test they require will be consistently priced at 25%.\r\n\r\nTransparent Billing:\r\nTransparency is at the core of our approach. Patients receive clear and concise bills, eliminating the guesswork associated with complex itemized statements. Our commitment to transparency extends to explaining the value of each test, fostering a sense of trust between our laboratory and the community.\r\n\r\nThe Benefits for Patients:\r\nCost Predictability:\r\nWith all tests priced at 25%, patients can predict and plan for their healthcare expenses more effectively. This predictability allows for better financial management and removes the element of surprise often associated with medical bills.\r\n\r\nEncouraging Preventive Care:\r\nAffordable healthcare promotes a proactive approach to health. Patients are more likely to undergo necessary tests and screenings when they know that the cost won't be a barrier. This emphasis on preventive care contributes to early detection and better health outcomes.\r\n\r\nOur Commitment to Community Health:\r\nInclusivity and Accessibility:\r\nOur all-test cost model reflects our commitment to making healthcare services accessible to everyone in the community. By removing financial barriers, we strive to ensure that individuals from all walks of life can benefit from the diagnostic services they need.\r\n\r\nCommunity Outreach Programs:\r\nBeyond our pricing model, we actively engage in community outreach programs. These initiatives aim to educate the community on the importance of regular health check-ups and screenings. Our goal is to empower individuals to take charge of their well-being.\r\n\r\nThe Future of Affordable Healthcare:\r\nAdvancements in Diagnostics:\r\nOur commitment to affordability does not compromise the quality of our services. We continually invest in the latest diagnostic technologies to provide accurate and reliable results. The future holds exciting possibilities for even more advanced and cost-effective healthcare solutions.\r\n\r\nCommunity Feedback and Improvement:\r\nWe value the input of our community. Regular feedback sessions and surveys allow us to understand the evolving needs of our patients. This collaborative approach ensures that we can continually refine our services to better serve the community.\r\n\r\nConclusion:\r\nAt [Your Laboratory Name], the all-test cost model represents more than just a pricing strategy – it's a commitment to fostering a healthier community. By breaking down financial barriers, we are paving the way for a future where everyone can access the diagnostic tests they need without the burden of exorbitant costs. Together, let's redefine healthcare affordability and create a healthier, more informed community.", BlogCategoryId =2, ResimDosyaAdi= "blog-2.jpg"},
             new BlogEntity { Id = 3, Title = "Get Free consulation from our special surgeon and doctors", Description = "Introduction:\r\n\r\nAt [Your Healthcare Center], we believe that everyone deserves access to expert medical advice without financial constraints. We are excited to announce a groundbreaking initiative – free consultations with our specialized surgeons and doctors. In this blog post, we'll delve into the significance of this program and how it aligns with our commitment to prioritizing your health.\r\n\r\nBridging the Gap:\r\nBreaking Down Financial Barriers:\r\nHealth concerns can be daunting, and financial considerations should never hinder someone from seeking the guidance they need. Our free consultation program aims to eliminate financial barriers, ensuring that individuals can connect with our specialists without the burden of upfront costs.\r\n\r\nEmpowering Informed Decisions:\r\nAccess to free consultations empowers individuals to make informed decisions about their health. Whether you're exploring treatment options, seeking a second opinion, or just want to discuss your health concerns, our specialized surgeons and doctors are here to provide guidance tailored to your unique needs.\r\n\r\nThe Specialists Behind the Program:\r\nExpertise Across Specializations:\r\nOur team of specialized surgeons and doctors bring a wealth of experience across various medical fields. From surgical interventions to medical consultations, our experts are dedicated to addressing a wide range of health concerns.\r\n\r\nHolistic Care Approach:\r\nOur specialists understand the importance of holistic care. During the free consultations, they not only address specific medical concerns but also consider the overall well-being of the individual. This comprehensive approach ensures that every aspect of your health is taken into account.\r\n\r\nHow to Access Free Consultation:\r\nSimple and Hassle-Free Process:\r\nAccessing our free consultation program is designed to be simple and hassle-free. Individuals can schedule their consultation through our website or by contacting our healthcare center directly. We've streamlined the process to prioritize your convenience.\r\n\r\nConfidential and Personalized:\r\nOur commitment to patient confidentiality is unwavering. During the free consultation, individuals can openly discuss their health concerns in a secure and private environment. Our specialists are dedicated to providing personalized attention to each individual's unique needs.\r\n\r\nCommunity Health Empowerment:\r\nPromoting Preventive Care:\r\nFree consultations are not just reactive; they also promote a culture of preventive care. By offering access to expert advice at no cost, we encourage individuals to seek guidance early, fostering a proactive approach to health.\r\n\r\nCommunity Education Initiatives:\r\nIn tandem with our free consultation program, we are launching community education initiatives. These programs aim to raise awareness about the importance of regular health check-ups, early detection, and the role of specialized medical advice in overall well-being.\r\n\r\nLooking Forward:\r\nExpanding Access:\r\nOur commitment to accessible healthcare doesn't end here. We envision expanding this program to reach even more individuals in our community. By continuously assessing community needs, we strive to evolve and enhance our services.\r\n\r\nFeedback and Improvement:\r\nYour feedback is invaluable to us. We encourage individuals who have availed our free consultation services to share their experiences, ensuring that we can continuously improve and tailor our services to meet the diverse needs of our community.\r\n\r\nConclusion:\r\nAt [Your Healthcare Center], our free consultation program is not just a service; it's a commitment to your health and well-being. We believe that expert medical advice should be accessible to all, and we are dedicated to empowering individuals to take control of their health journey. Schedule your free consultation today and embark on a path towards a healthier, more informed life.", BlogCategoryId =3, ResimDosyaAdi= "blog-4.jpg" }
            

             );
            modelBuilder.Entity<DoctorCommentEntity>().HasData(
           new DoctorCommentEntity { Id = 1, Title = "çok güzel ", Description = "r Illum libero t al nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore.",DoctorId=1 },
           new DoctorCommentEntity { Id = 2, Title = "harika", Description = "Non illo quas blanditiis repellendus lsantium pariatur repudiandae!\r\n\r\nLorem ipsum dolor sit amet, consectetur adipisicing elit. Possimus natus, consectetur? Illum libero vel nihil nisi quae, voluptatem, sapiente necessitatibus distinctio voluptates, iusto qui. Laboriosam autem, nam voluptate in beatae. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae iure officia nihil nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore.",DoctorId = 2 },
            new DoctorCommentEntity { Id = 3, Title = "bok gibi", Description = "Non illo quas blanditiis repellendus laboriosam minima animi. Consectetur accusantium pariatur repudiandae!\r\n\r\nLorem ipsum dolor sit amet, consectetur adipisicing elit. Possimus natus, consectetur? Illum libero vel nihil nisi quae, voluptatem, sapiente necessitatibus distinctio voluptates, iusto qui. Laboriosam autem, nam voluptate in beatae. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae iure officia nihil nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore." ,DoctorId = 3 }


            );
            modelBuilder.Entity<BlogCategoryEntity>().HasData(
           new BlogCategoryEntity { Id = 1, Title = "Medicine" },
           new BlogCategoryEntity { Id = 2, Title = "Equipments" },
           new BlogCategoryEntity { Id = 3, Title = "Heart" },
            new BlogCategoryEntity { Id = 4, Title = "Free counselling" },
           new BlogCategoryEntity { Id = 5, Title = "Lab test " }

           );
            modelBuilder.Entity<AppointmentEntity>().HasData(
         new AppointmentEntity { Id = 1, PatientId = 1,DoctorId=1,DoctorCategoryId=1,DateTime= DateTime.UtcNow},
         new AppointmentEntity { Id = 2, PatientId = 2, DoctorId = 1, DoctorCategoryId = 2, DateTime = DateTime.UtcNow },
         new AppointmentEntity { Id = 3, PatientId = 1, DoctorId = 3, DoctorCategoryId = 3, DateTime = DateTime.UtcNow },
          new AppointmentEntity { Id = 4, PatientId = 2, DoctorId = 4, DoctorCategoryId = 4, DateTime = DateTime.UtcNow },
         new AppointmentEntity { Id = 5, PatientId = 1, DoctorId = 5, DoctorCategoryId = 5, DateTime = DateTime.UtcNow }

         );
            //modelBuilder.Entity<AppointmentEntity>()
            //   .HasOne(a => a.Doctor)
            //   .WithMany(d => d.Appointments)
            //   .HasForeignKey(a => a.DoctorId);

            //modelBuilder.Entity<AppointmentEntity>()
            //    .HasOne(a => a.Patient)
            //    .WithMany(p => p.Appointments)
            //    .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<PatientEntity>().HasData(
          new PatientEntity
          {
              Id = 1,
              Name = "Ali Rıza ",
              Surname = "Canbulan",
              Email = "aliriza@canbulan.com",
              Phone = "05554443311",
              Password = "12345"



          },

          new PatientEntity
          {
              Id = 2,
              Name = "Suleyman",
              Surname = "Canbulan",
              Email = "alirıza@canbulan.com",
              Phone = "05554443311",
              Password = "12345"



          },

		  new PatientEntity
		  {
			  Id = 3,
			  Name = "Ssaasddsa",
			  Surname = "Canbulan",
			  Email = "canbulan1849@gmail.com",
			  Phone = "05554443311",
			  Password = "12345"



		  },
          new PatientEntity
          {
              Id = 4,
              Name = "xzxzxan",
              Surname = "Canbulan",
              Email = "alirıza@canbulan.com",
              Phone = "05554443311",
              Password = "12345"



          },

		  new PatientEntity
		  {
			  Id = 5,
			  Name = "Sulxxxx",
			  Surname = "Canbulan",
			  Email = "alirıza@canbulan.com",
			  Phone = "05554443311",
			  Password = "12345"



		  }
		   );

            modelBuilder.Entity<AdminEntity>().HasData(
               new AdminEntity
               {
                   Id = 1,
                   Name = "Ali Rıza ",
                   Surname = "Canbulan",
                   Email = "aliriza@canbulan.com",
                   Phone = "05554442211",
                   Password = "1234",
                   Cv = "fdsjfıldjsfldjflıdjsfıjldsjfdsı"
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
            modelBuilder.Entity<ContactEntity>().HasData(
             new ContactEntity() { Id = 1, Fullname = "Mehmet Kirişoğlu", Email = "aliriza@canbulan.com",Phone = "05554443322", Topic="FDFSDF",Text = "fldşjsfşdjsşf"},
             new ContactEntity() { Id = 2, Fullname = "Ali Rıza Canbulan", Email = "aliriza@canbulan.com", Phone = "05554443322" , Topic = "FDFSDF", Text = "fldşjsfşdjsşf" },
             new ContactEntity() { Id = 3, Fullname = "Rıza Argun", Email = "aliriza@canbulan.com", Phone = "05554443322", Topic = "FDFSDF", Text = "fldşjsfşdjsşf" }


                  );
            modelBuilder.Entity<CommentEntity>().HasData(
            new CommentEntity() { Id = 1, BlogId = 2, Text = "Home" ,PatientId=1 },
            new CommentEntity() { Id = 2, BlogId = 2, Text = "About", PatientId = 1 },
            new CommentEntity() { Id = 3, BlogId = 2, Text = "Services", PatientId = 1 },
            new CommentEntity() { Id = 4, BlogId = 2, Text = "Departments", PatientId = 2 },
            new CommentEntity() { Id = 5, BlogId = 2, Text = "Doctors", PatientId = 2 },
            new CommentEntity() { Id = 6, BlogId = 2, Text = "Blog", PatientId = 2 },
            new CommentEntity() { Id = 7, BlogId = 2, Text = "Contact", PatientId = 2 }
            );
			modelBuilder.Entity<PatientCommentEntity>().HasData(
		   new PatientCommentEntity { Id = 1, Title = "çok güzel ", Description = "r Illum libero t al nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore.", PatientId = 1 },
		   new PatientCommentEntity { Id = 2, Title = "harika", Description = "Non illo quas blanditiis repellendus lsantium pariatur repudiandae!\r\n\r\nLorem ipsum dolor sit amet, consectetur adipisicing elit. Possimus natus, consectetur? Illum libero vel nihil nisi quae, voluptatem, sapiente necessitatibus distinctio voluptates, iusto qui. Laboriosam autem, nam voluptate in beatae. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae iure officia nihil nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore.", PatientId = 2 },
			new PatientCommentEntity { Id = 3, Title = "bok gibi", Description = "Non illo quas blanditiis repellendus laboriosam minima animi. Consectetur accusantium pariatur repudiandae!\r\n\r\nLorem ipsum dolor sit amet, consectetur adipisicing elit. Possimus natus, consectetur? Illum libero vel nihil nisi quae, voluptatem, sapiente necessitatibus distinctio voluptates, iusto qui. Laboriosam autem, nam voluptate in beatae. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae iure officia nihil nemo, repudiandae itaque similique praesentium non aut nesciunt facere nulla, sequi sunt nam temporibus atque earum, ratione, labore.", PatientId = 1 }


			);
            modelBuilder.Entity<ServiceBlogEntity>().HasData(
         new ServiceBlogEntity { Id = 1, Title = "Child care ", Description = "Parenting is an exhilarating journey filled with joy, challenges, and numerous decisions to make, one of the most significant being child care. Whether you're a new parent or navigating the world of child care for the first time, understanding the essentials is crucial. In this comprehensive guide, we'll explore various aspects of child care to empower you in providing the best possible environment for your child's growth and development.",  ResimDosyaAdi = "service-1.jpg" },
         new ServiceBlogEntity { Id = 2, Title = "Personal Care", Description = "In the hustle and bustle of daily life, it's easy to overlook the significance of personal care. However, dedicating time to prioritize your well-being is a powerful investment in your physical and mental health. In this article, we'll explore the importance of personal care, its impact on overall well-being, and practical tips for incorporating self-care into your daily routine.",  ResimDosyaAdi = "service-2.jpg" },
          new ServiceBlogEntity { Id = 3, Title = "CT scan", Description = "In the realm of medical imaging, the Computed Tomography (CT) scan stands as a revolutionary tool, offering a detailed and cross-sectional view of the human body. From its inception to modern applications, this article explores the intricacies of CT scans, their significance in diagnosis, and the advancements shaping the future of medical imaging.",  ResimDosyaAdi = "service-3.jpg" },
            new ServiceBlogEntity { Id = 4, Title = "Joint replacement ", Description = "Joint replacement surgery has emerged as a transformative solution for individuals grappling with debilitating joint conditions that significantly impact their quality of life. In this article, we delve into the intricacies of joint replacement, exploring the types of procedures, advancements in technology, and the life-changing impact these surgeries have on patients.",  ResimDosyaAdi = "service-4.jpg" },
         new ServiceBlogEntity { Id = 5, Title = "Examination & Diagnosis", Description = "In the intricate realm of healthcare, the processes of examination and diagnosis form the cornerstone of understanding and addressing a patient's medical condition. This article navigates through the significance of these fundamental steps, exploring the artistry of clinical examination and the precision of diagnostic methodologies.", ResimDosyaAdi = "service-6.jpg" },
          new ServiceBlogEntity { Id = 6, Title = "Alzheimer's disease", Description = "Alzheimer's disease, a progressive neurodegenerative disorder, presents a complex and challenging landscape for both individuals diagnosed and their families. This article aims to shed light on the multifaceted nature of Alzheimer's, exploring its causes, symptoms, coping strategies, and the ongoing research endeavors working towards a deeper understanding and effective treatments.",  ResimDosyaAdi = "service-8.jpg" }

          );

            base.OnModelCreating(modelBuilder);

        }

    }
}
