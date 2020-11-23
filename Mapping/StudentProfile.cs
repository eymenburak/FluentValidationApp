using AutoMapper;
using FluentValidationApp.DTOs;
using FluentValidationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d => d.FirstName, option => option.MapFrom(x => x.Name))
                .ForMember(d => d.LastName, option => option.MapFrom(x => x.Surname))
                .ForMember(d => d.SchoolNo, option => option.MapFrom(x => x.SchoolNumber));
        }
    }
}
