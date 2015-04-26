using Imarley.Controle.Application.Interface;
using Imarley.Controle.Domain.Entities;
using Imarley.Controle.Domain.Interfaces.Services;

namespace Imarley.Controle.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        :base(clienteService)
        {
            _clienteService = clienteService;
        }
        
    }
}
