using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContext.Domain.Entities;
using PagamentoContext.Domain.ValueObjects;
using System;

namespace PagamentoContext.Tests.Entities
{
    [TestClass]
    public class AlunoTests
    {
        private readonly Nome _nome;
        private readonly Documento _documento;
        private readonly Email _email;
        private readonly Endereco _endereco;
        private readonly Aluno _aluno;
        private readonly Assinatura _assinatura;

        public AlunoTests()
        {
            _nome = new Nome("Thiago", "Borges");
            _documento = new Documento("98575444018", Domain.Enums.TipoDocumento.Cpf);
            _email = new Email("thiago@dominiorico.com.br");
            _endereco = new Endereco("Rua Teste", "1", "Bairro Teste", "Cidade Teste", "PR", "123456");

            _aluno = new Aluno(_nome, _documento, _email);

            _assinatura = new Assinatura(null);
        }

        [TestMethod]
        public void Erro_Com_Assinatura_Ativa()
        {
            var pagamento = new PayPalPagamento("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Thiago", _documento, _endereco, _email);
            _assinatura.AdicionarPagamento(pagamento);

            _aluno.AdicionarAssinatura(_assinatura);
            _aluno.AdicionarAssinatura(_assinatura);

            Assert.IsTrue(_aluno.Invalid);
        }

        [TestMethod]
        public void Erro_Com_Assinatura_Sem_Pagamento()
        {
            _aluno.AdicionarAssinatura(_assinatura);
            Assert.IsTrue(_aluno.Invalid);
        }

        [TestMethod]
        public void Sucesso_Sem_Assinatura_Ativa()
        {
            var pagamento = new PayPalPagamento("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Thiago", _documento, _endereco, _email);
            _assinatura.AdicionarPagamento(pagamento);

            _aluno.AdicionarAssinatura(_assinatura);
            
            Assert.IsTrue(_aluno.Valid);
        }
    }
}
