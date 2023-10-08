﻿using AutoMapper;
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







        }
    }
}