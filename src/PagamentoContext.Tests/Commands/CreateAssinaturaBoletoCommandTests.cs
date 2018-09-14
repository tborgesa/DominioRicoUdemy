using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContext.Domain.Commands;

namespace PagamentoContext.Tests.Commands
{
    [TestClass]
    public class CreateAssinaturaBoletoCommandTests
    {
        [TestMethod]
        public void Erro_Com_Nome_Invalido()
        {
            var command = new CreateAssinaturaBoletoCommand();

            command.PrimeiroNome = "";
            command.UltimoNome = "";

            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }
    }

    
}
