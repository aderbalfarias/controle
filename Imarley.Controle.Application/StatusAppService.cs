using Imarley.Controle.Application.Interface;
using Imarley.Controle.Domain.Entities;
using Imarley.Controle.Domain.Interfaces.Services;

namespace Imarley.Controle.Application
{
    public class StatusAppService : AppServiceBase<Status>, IStatusAppService
    {
        private readonly IStatusService _statusService;

        public StatusAppService(IStatusService statusService)
        :base(statusService)
        {
            _statusService = statusService;
        }
    }
}
