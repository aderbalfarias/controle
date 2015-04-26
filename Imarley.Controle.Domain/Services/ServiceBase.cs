using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Imarley.Controle.Domain.Interfaces.Repositories;
using Imarley.Controle.Domain.Interfaces.Services;

namespace Imarley.Controle.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> Listar()
        {
            return _repository.Listar();
        }

        public IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> filtro)
        {
            return _repository.Pesquisar(filtro);
        }

        public void Cadastrar(TEntity obj)
        {
            _repository.Cadastrar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public void Deletar(int codigo)
        {
            _repository.Deletar(codigo);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
