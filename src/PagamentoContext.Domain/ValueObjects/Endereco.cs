using Flunt.Validations;
using PagamentoContext.Shared.ValueObjects;

namespace PagamentoContext.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;

            AddNotifications(new Contract()
                .HasMinLen(Logradouro, 3, "Endereco.Logradouro", "Logradouro deve conter pelo menos 3 caracteres.")
                .HasMinLen(Numero, 1, "Endereco.Numero", "Número deve conter pelo menos 1 caracter.")
                .HasMinLen(Bairro, 3, "Endereco.Bairro", "Bairro deve conter pelo menos 3 caracteres.")
                .HasMinLen(Cidade, 3, "Endereco.Cidade", "Cidade deve conter pelo menos 3 caracteres.")
                .HasMinLen(Estado, 3, "Endereco.Estado", "Estado deve conter pelo menos 3 caracteres.")
                .HasMinLen(Cep, 3, "Endereco.Cep", "Cep deve conter pelo menos 3 caracteres.")
                );
        }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
    }
}
