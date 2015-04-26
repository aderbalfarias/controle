using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Imarley.Controle.Application.Interface;
using Imarley.Controle.Domain.Interfaces.Services;

namespace Imarley.Controle.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {

        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }


        public IEnumerable<TEntity> Listar()
        {
            return _serviceBase.Listar();
        }

        public IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> filtro)
        {
            return _serviceBase.Pesquisar(filtro);
        }

        public void Cadastrar(TEntity obj)
        {
            _serviceBase.Cadastrar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _serviceBase.Atualizar(obj);
        }

        public void Deletar(int codigo)
        {
            _serviceBase.Deletar(codigo);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
