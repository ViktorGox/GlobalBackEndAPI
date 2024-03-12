using AutoMapper;
using GlobalBackEndAPI.RegressionTesting.DTO;
using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.SetUp
{
    public class RTMappingProfile : Profile
    {
        public RTMappingProfile()
        {
            CreateMap<Test, TestDTO>();
            CreateMap<Sprint, SprintDTO>();

            CreateMap<TestDTO, Test>();
            CreateMap<SprintDTO, Sprint>();
        }
    }
}
