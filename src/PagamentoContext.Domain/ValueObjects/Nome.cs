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
                .HasMinLen(PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter pelo menos 3 caracteres.")
                .HasMinLen(UltimoNome, 3, "Nome.UltimoName", "Sobrenome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(PrimeiroNome, 40, "Nome.PrimeiroNome", "Nome deve conter até 40 caracteres."));
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
