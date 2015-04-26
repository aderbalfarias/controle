using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Subimos pra memória a dll de testes NUNIT
using Imarley.Controle.Data.Contexto;
using NUnit.Framework;

namespace Imarley.Controle.Test.DataAccess
{
    [TestFixture]
    public sealed class ConexaoTest
    {
        [Test]
        public void TESTAR_CRIACAO_DO_BANCO()
        {
            var db = new Context();

            var context = new Context.ContextCustomInitializer();
            context.InitializeDatabase(db);

        }

        [Test]
        public void TESTAR_EXCLUSAO_DO_BANCO()
        {
            var conexao = new Context();
            conexao.ExcluirBanco();
        }
    }
}
