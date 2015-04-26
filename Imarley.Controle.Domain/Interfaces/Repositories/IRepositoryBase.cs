using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Imarley.Controle.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Listar();
        IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, Boolean>> filtro);
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Deletar(int codigo);
        void Dispose();
    }
}
