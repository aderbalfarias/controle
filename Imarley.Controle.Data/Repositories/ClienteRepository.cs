using System;
using System.Linq;
using Imarley.Controle.Domain.Entities;
using Imarley.Controle.Domain.Interfaces.Repositories;

namespace Imarley.Controle.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public new void Cadastrar(Cliente obj)
        {
            obj.DataCadastro = DateTime.Now.Date;
            obj.DataAtualizacao = DateTime.Now.Date;

            Db.Clientes.Add(obj);
            Db.SaveChanges();
        }

        public new void Atualizar(Cliente obj)
        {
            var codigo = obj.Id;

            var cliente = Db.Clientes.Single(
                    x => x.Id == codigo);

            cliente.Nome = obj.Nome;
            cliente.Email = obj.Email;
            cliente.Endereco = obj.Endereco;
            cliente.Telefone = obj.Telefone;
            cliente.Celular = obj.Celular;
            cliente.Descricao = obj.Descricao;
            cliente.StatusId = obj.StatusId;
            cliente.CategoriaId = obj.CategoriaId;
            cliente.DataAtualizacao = DateTime.Now.Date;

            Db.SaveChanges();
        }


    }

}
