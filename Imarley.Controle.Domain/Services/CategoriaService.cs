using Imarley.Controle.Domain.Entities;
using Imarley.Controle.Domain.Interfaces.Repositories;
using Imarley.Controle.Domain.Interfaces.Services;

namespace Imarley.Controle.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IClienteRepository _clienteRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, IClienteRepository clienteRepository)
        : base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _clienteRepository = clienteRepository;
        }

        
    }
}
