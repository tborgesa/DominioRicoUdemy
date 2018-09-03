using PagamentoContext.Shared.ValueObjects;

namespace PagamentoContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string endereco)
        {
            Endereco = endereco;
        }

        public string Endereco { get; private set; }
    }
}
