using AutoMapper;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Category;

namespace NewsChannel.IocConfig.AutoMapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}