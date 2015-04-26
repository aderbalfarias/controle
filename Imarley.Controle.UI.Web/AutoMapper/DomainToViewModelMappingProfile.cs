using AutoMapper;
using Imarley.Controle.Domain.Entities;
using Imarley.Controle.UI.Web.ViewModels;

namespace Imarley.Controle.UI.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; } 
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Status, StatusViewModel>();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            
        }

    }
}