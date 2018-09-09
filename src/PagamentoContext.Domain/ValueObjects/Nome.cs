using Flunt.Validations;
using PagamentoContext.Shared.ValueObjects;

namespace PagamentoContext.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            AddNotifications(new Contract()
                .HasMinLen(PrimeiroNome, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres.")
                .HasMinLen(UltimoNome, 3, "Name.UltimoName", "Sobrenome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(PrimeiroNome, 40, "Name.FirstName", " deve conter até 40 caracteres."));
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
