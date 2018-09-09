using Flunt.Validations;
using PagamentoContext.Domain.Enums;
using PagamentoContext.Shared.ValueObjects;

namespace PagamentoContext.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string numero, TipoDocumento tipo)
        {
            Numero = numero;
            Tipo = tipo;

            AddNotifications(new Contract().IsTrue(Validate(), "Documento.Numero", "Documento inválido."));
        }

        public string Numero { get; private set; }
        public TipoDocumento Tipo { get; private set; }

        private bool Validate()
        {
            if (Tipo == TipoDocumento.Cnpj && Numero.Length == 14)
                return true;

            if (Tipo == TipoDocumento.Cpf && Numero.Length == 11)
                return true;

            return false;
        }
    }
}
