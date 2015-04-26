using Imarley.Controle.Application.Interface;
using Imarley.Controle.Domain.Entities;
using Imarley.Controle.Domain.Interfaces.Services;

namespace Imarley.Controle.Application
{
    public class CategoriaAppService : AppServiceBase<Categoria>, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(ICategoriaService categoriaService)
        :base(categoriaService)
        {
            _categoriaService = categoriaService;
        }

    }
}
