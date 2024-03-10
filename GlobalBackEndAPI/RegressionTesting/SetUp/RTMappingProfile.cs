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
            CreateMap<TestDTO, Test>();
        }
    }
}
