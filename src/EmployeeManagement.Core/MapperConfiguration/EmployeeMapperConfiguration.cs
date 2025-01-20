using AutoMapper;
using EmpMgmt.Core.Features.AddOrUpdateEmployeeFeature;
using EmpMgmt.DataAccess.Entities;

namespace EmpMgmt.Core.MapperConfiguration
{
    public class EmployeeMapperConfiguration : Profile
    {
        public EmployeeMapperConfiguration()
        {
            CreateMap<AddOrUpdateEmployeeModel, Employee>();
        }
    }
}
