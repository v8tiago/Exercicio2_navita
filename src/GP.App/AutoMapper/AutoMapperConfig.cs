using AutoMapper;
using GP.App.ViewModels;
using GP.Business.Models;

namespace GP.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig ()
        {
            CreateMap<Marca, MarcaViewModel>().ReverseMap();
            CreateMap<Patrimonio, PatrimonioViewModel>().ReverseMap();
        }
    }
}
