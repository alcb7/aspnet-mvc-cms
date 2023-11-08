using AutoMapper;
using Cms.Data.Models.Entities;
using Cms.Web.Api.DTOs;

namespace Cms.Web.Api.MappingProfiles
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
            CreateMap<DepartmentCreateDto, DepartmentEntity>().ReverseMap();
            CreateMap<DepartmentUpdateDto, DepartmentEntity>().ReverseMap();
			CreateMap<PatientCommentDto, PatientCommentEntity>().ReverseMap();
            CreateMap<DoctorCommentCreateDto, DoctorCommentEntity>().ReverseMap();
            CreateMap<DoctorCommentUpdateDto, DoctorCommentEntity>().ReverseMap();
            CreateMap<ServiceBlogCreateDto, ServiceBlogEntity>().ReverseMap();
            CreateMap<ServiceBlogUpdateDto, ServiceBlogEntity>().ReverseMap();
            CreateMap<CommentCreateDto, CommentEntity>().ReverseMap();





        }
    }
}

