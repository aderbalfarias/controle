using AutoMapper;
using Imarley.Controle.Domain.Entities;
using Imarley.Controle.UI.Web.ViewModels;


namespace Imarley.Controle.UI.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<StatusViewModel, Status>();
            Mapper.CreateMap<CategoriaViewModel, Categoria>();
            Mapper.CreateMap<ClienteViewModel, Cliente>();
        }
    }
}