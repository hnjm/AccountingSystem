using AutoMapper;
using BL.BusinessModels.Models;
using Module.Enums;

namespace PL.WebAPI.ViewModels.Mappings
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<OperationModel, OperationViewModel>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.CreateDate));
            CreateMap<OperationViewModel, OperationModel>();
        }
    }
}
