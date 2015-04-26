using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imarley.Controle.UI.Web.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        public virtual ICollection<ClienteViewModel> Clientes { get; set; }
        
    }
}
