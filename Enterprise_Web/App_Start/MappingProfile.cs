using AutoMapper;
using Enterprise_Web.Dtos;
using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprise_Web.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Contribution, ContributionDto>();
            Mapper.CreateMap<ContributionDto, Contribution>();
            Mapper.CreateMap<StudentDto, User_Student_Detail>();
            Mapper.CreateMap<User_Student_Detail, StudentDto>();
            //Mapper.CreateMap<AdminDto, User_Admin_Detail>();
            //Mapper.CreateMap<User_Admin_Detail, AdminDto>();
        }
    }
}