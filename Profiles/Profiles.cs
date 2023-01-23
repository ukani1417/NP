using AutoMapper;
using NP.Models;
using NP.DTOs.Student;
using NP.DTOs.Class;
using NP.DTOs.Subject;
using NP.DTOs.Test;
namespace NP.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            #region Student
                CreateMap<StudentDTO,Student>().ReverseMap();
                CreateMap<AddStudentDTO,Student>().ReverseMap();
                CreateMap<UpdateStudentDTO,Student>().ReverseMap();
            #endregion

            #region Class
                CreateMap<ClassDTO,Class>().ReverseMap();
                CreateMap<AddClassDTO,Class>().ReverseMap();
                CreateMap<UpdateClassDTO,Class>().ReverseMap();    
            #endregion

            #region Subjects
                CreateMap<SubjectDTO,Subject>().ReverseMap();
                CreateMap<AddSubjectDTO,Subject>().ReverseMap();
                CreateMap<UpdateSubjectDTO,Subject>().ReverseMap();
            #endregion
            
            #region Tests
                CreateMap<TestDTO,Test>().ReverseMap();
                CreateMap<AddTestDTO,Test>().ReverseMap();
                CreateMap<UpdateTestDTO,Test>().ReverseMap();
            #endregion
        }
    }
}