using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContext.Domain.Entities;
using PagamentoContext.Domain.Queries;
using PagamentoContext.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PagamentoContext.Tests.Entities
{
    [TestClass]
    public class AlunoQueriesTests
    {
        private IList<Aluno> _alunos;

        public AlunoQueriesTests()
        {
            _alunos = new List<Aluno>();

            for (int i = 0; i < 10; i++)
            {
                _alunos.Add(new Aluno(
                    new Nome("Aluno", i.ToString("D2")),
                    new Documento("111111111" + i.ToString("D2"), Domain.Enums.TipoDocumento.Cpf),
                    new Email(i.ToString("D2") + "@balta.io")
                    ));
            }
        }

        [TestMethod]
        public void Retorno_Null_Documento_Nao_Existe()
        {
            var exp = AlunoQueries.GetAluno("44444444444");
            var aluno = _alunos.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, aluno);
        }
    }
}
