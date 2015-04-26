using Imarley.Controle.Domain.Entities;
using Imarley.Controle.Domain.Interfaces.Repositories;
using Imarley.Controle.Domain.Interfaces.Services;

namespace Imarley.Controle.Domain.Services
{
    public class StatusService : ServiceBase<Status>, IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        :base(statusRepository)
        {
            _statusRepository = statusRepository;
        }

    }
}
