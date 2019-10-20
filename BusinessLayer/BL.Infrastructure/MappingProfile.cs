using AutoMapper;
using BL.BusinessModels.Models;
using DL.DomainModels.Entities;

namespace BL.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Operation, OperationModel>().ReverseMap();
        }
    }
}
