using Flunt.Validations;
using PagamentoContext.Shared.ValueObjects;

namespace PagamentoContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(new Contract().IsEmail(Endereco,"Email.Endereco","E-mail inválido"));
        }

        public string Endereco { get; private set; }
    }
}
