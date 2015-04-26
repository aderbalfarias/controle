using System.Collections.Generic;

namespace Imarley.Controle.Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
