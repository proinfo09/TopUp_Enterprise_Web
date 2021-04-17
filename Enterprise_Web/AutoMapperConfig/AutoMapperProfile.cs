using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Enterprise_Web.Models;
using Enterprise_Web.Dtos;

namespace Enterprise_Web.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contribution, ContributionDto>();
            CreateMap<User_Student_Detail, StudentDto>();
            CreateMap<User_Admin_Detail, AdminDto>();
            CreateMap<User_Marketing_Manager_Detail, MmDto>();
            CreateMap<User_Marketing_Coordinator_Detail, McDto>();
            CreateMap<User_Guest_Detail, GuestDto>();
        }

    }
}