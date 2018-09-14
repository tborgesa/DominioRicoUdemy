using Flunt.Notifications;
using Flunt.Validations;
using PagamentoContext.Domain.Enums;
using PagamentoContext.Shared.Commands;
using System;

namespace PagamentoContext.Domain.Commands
{
    public class CreateAssinaturaPayPalCommand : Notifiable, ICommand
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public string CodigoTransacao { get; set; }
        public string NumeroPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Pagador { get; set; }
        public string DocumentoPagador { get; set; }
        public TipoDocumento TipoDocumentoPagador { get; set; }
        public string EmailPagador { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public void Validate()
        {
            //Fazer todas as validações simples.
            //Isso evita chegar nas regras de negócio complexas (que gastam recurso do Banco de Dados).
            AddNotifications(new Contract()
                .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "Nome deve conter pelo menos 3 caracteres.")
                .HasMinLen(UltimoNome, 3, "UltimoName", "Sobrenome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(PrimeiroNome, 40, "PrimeiroNome", " deve conter até 40 caracteres."));
        }
    }
}
