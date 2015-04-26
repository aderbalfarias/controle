using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imarley.Controle.UI.Web.ViewModels
{
    public class StatusViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string Nome { get; set; }

        public virtual ICollection<ClienteViewModel> Clientes { get; set; }
        
    }
}
