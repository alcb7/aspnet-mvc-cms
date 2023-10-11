using AutoMapper;
using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.DTOs;

namespace Cms.Web.Mvc.Admin.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DoctorCreateDto, DoctorEntity>().ReverseMap();
            CreateMap<DoctorUpdateDto, DoctorEntity>().ReverseMap();
            CreateMap<AdminUpdateDto, AdminEntity>().ReverseMap();
            CreateMap<AdminCreateDto, AdminEntity>().ReverseMap();
            CreateMap<PatientCreateDto, PatientEntity>().ReverseMap();
            CreateMap<PatientUpdateDto, PatientEntity>().ReverseMap();
            CreateMap<BlogCreateDto, BlogEntity>().ReverseMap();
            CreateMap<BlogUpdateDto, BlogEntity>().ReverseMap();
            CreateMap<AppointmentCreateDto, AppointmentEntity>().ReverseMap();
            CreateMap<AppointmentUpdateDto, AppointmentEntity>().ReverseMap();






        }
    }
}
