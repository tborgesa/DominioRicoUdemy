using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContext.Domain.Commands;
using PagamentoContext.Domain.Handlers;
using PagamentoContext.Tests.Mocks;
using System;

namespace PagamentoContext.Tests.Commands
{
    [TestClass]
    public class AssinaturaHandlerTests
    {
        [TestMethod]
        public void Erro_Com_Documento_Existente()
        {
            var handler = new AssinaturaHandler(new FakeAlunoRepository(), new FakeEmailService());
            var command = new CreateAssinaturaBoletoCommand();

            command.PrimeiroNome = "Thiago";
            command.UltimoNome = "Borges";
            command.Documento = "99999999999";
            command.Email = "thiago@balta.io";

            command.CodigoBarra = "123456789";
            command.NossoNumero = "123456789567";

            command.NumeroPagamento = "123432";
            command.DataPagamento = DateTime.Now;
            command.DataExpiracao = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPago = 60;
            command.Pagador = "Thiago Borges";
            command.DocumentoPagador = "88888888888";
            command.TipoDocumentoPagador = Domain.Enums.TipoDocumento.Cpf;
            command.EmailPagador = "pagador@balta.io";
            command.Logradouro = "Rua 234";
            command.Numero = "56";
            command.Bairro = "Bairro 40";
            command.Cidade = "Cidade 10";
            command.Estado = "PR";
            command.Cep = "12345678901";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);

        }
    }


}
