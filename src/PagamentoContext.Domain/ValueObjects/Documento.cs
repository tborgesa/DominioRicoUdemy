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
        }

        public string Numero { get; private set; }
        public TipoDocumento Tipo { get; private set; }
    }
}
