using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContext.Domain.ValueObjects;

namespace PagamentoContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentoTests
    {
        //Red, Green, Refactor
        [TestMethod]
        public void Erro_Cnpj_Invalido()
        {
            var doc = new Documento("123", Domain.Enums.TipoDocumento.Cnpj);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void Sucesso_Cnpj_Valido()
        {
            var doc = new Documento("83816147000181", Domain.Enums.TipoDocumento.Cnpj);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void Erro_Cpf_Invalido()
        {
            var doc = new Documento("123", Domain.Enums.TipoDocumento.Cpf);
            Assert.IsTrue(doc.Invalid);
        }

        [DataTestMethod]
        [DataRow("57362160003")]
        [DataRow("30667997008")]
        [DataRow("59888112058")]
        public void Sucesso_Cpf_Valido(string cpf)
        {
            var doc = new Documento(cpf, Domain.Enums.TipoDocumento.Cpf);
            Assert.IsTrue(doc.Valid);
        }
    }
}
