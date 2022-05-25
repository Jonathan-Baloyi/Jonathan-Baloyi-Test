using AutoMapper;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;

namespace CleanArch.Mvc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping profiles for AutoMapper
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
        }
    }
}
