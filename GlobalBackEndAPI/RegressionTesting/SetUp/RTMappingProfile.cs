using AutoMapper;
using GlobalBackEndAPI.RegressionTesting.DTO;
using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.SetUp
{
    public class RTMappingProfile : Profile
    {
        public RTMappingProfile()
        {
            CreateMap<Module, ModuleDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<Sprint, SprintDTO>();
            CreateMap<Status, StatusDTO>();
            CreateMap<Step, StepDTO>();
            CreateMap<Test, TestDTO>();

            CreateMap<ModuleDTO, Module>();
            CreateMap<RoleDTO, Role>();
            CreateMap<SprintDTO, Sprint>();
            CreateMap<StatusDTO, Sprint>();
            CreateMap<StepDTO, Step>();
            CreateMap<TestDTO, Test>();
        }
    }
}
