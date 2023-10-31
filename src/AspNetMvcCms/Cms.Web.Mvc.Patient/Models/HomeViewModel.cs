using Cms.Data.Models.Entities;

namespace Cms.Web.Mvc.Patient.Models
{
    public class HomeViewModel
    {
        public List<DoctorCommentEntity> DoctorComments { get; set; }
        public List<PatientEntity> Patients { get; set; }
        public List<DepartmentEntity> Departments { get; set; }
        public List<BlogEntity> Blogs { get; set; }
        public List<DoctorEntity> Doctors { get; set; }
		public List<NavbarEntity> Navbars { get; set; }



	}
}
