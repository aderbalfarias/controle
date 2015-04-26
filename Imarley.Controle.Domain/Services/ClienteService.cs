using Imarley.Controle.Domain.Entities;
using Imarley.Controle.Domain.Interfaces.Repositories;
using Imarley.Controle.Domain.Interfaces.Services;

namespace Imarley.Controle.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

    }
}
