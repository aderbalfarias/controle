using System;

namespace Imarley.Controle.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual Status Status { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
