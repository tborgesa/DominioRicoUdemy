using PagamentoContext.Shared.ValueObjects;

namespace PagamentoContext.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            if (string.IsNullOrEmpty(PrimeiroNome))
                AddNotification("Nome.PrimeiroNome", "Nome inválido");
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
