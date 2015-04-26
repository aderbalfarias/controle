using System;
using System.ComponentModel.DataAnnotations;

namespace Imarley.Controle.UI.Web.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }
        public string Celular { get; set; }
        
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Endereco { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data Atualização")]
        public DateTime DataAtualizacao { get; set; }
        public virtual StatusViewModel Status { get; set; }
        public virtual CategoriaViewModel Categoria { get; set; }

    }
}
