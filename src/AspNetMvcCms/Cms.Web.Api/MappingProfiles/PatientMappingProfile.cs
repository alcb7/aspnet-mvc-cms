using AutoMapper;
using Cms.Data.Models.Entities;
using Cms.Web.Api.DTOs;

namespace Cms.Web.Api.MappingProfiles
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<PatientCreateDto, PatientEntity>().ReverseMap();
            CreateMap<PatientUpdateDto, PatientEntity>().ReverseMap();






        }
    }
}
