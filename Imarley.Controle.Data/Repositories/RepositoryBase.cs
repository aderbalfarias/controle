using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Imarley.Controle.Domain.Interfaces.Repositories;
using Imarley.Controle.Data.Contexto;

namespace Imarley.Controle.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected Context Db = new Context();

        public IEnumerable<TEntity> Listar()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> filtro)
        {
            return Db.Set<TEntity>().Where(filtro);
        }

        public void Cadastrar(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Deletar(int codigo)
        {
            var obj = Db.Set<TEntity>().Find(codigo);
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
