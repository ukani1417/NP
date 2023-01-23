using AutoMapper;
using NP.Models;
using NP.DTOs.Student;
using NP.DTOs.Class;

namespace NP.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<StudentDTO,Student>().ReverseMap();
            CreateMap<ClassDTO,Class>().ReverseMap();
            CreateMap<AddStudentDTO,Student>().ReverseMap();
            CreateMap<AddClassDTO,Class>().ReverseMap();
            CreateMap<UpdateClassDTO,Class>().ReverseMap();
            CreateMap<UpdateStudentDTO,Student>().ReverseMap();
        }
    }
}