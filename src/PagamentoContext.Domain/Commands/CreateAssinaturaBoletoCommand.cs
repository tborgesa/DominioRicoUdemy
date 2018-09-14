using PagamentoContext.Domain.Enums;
using PagamentoContext.Shared.Commands;
using System;

namespace PagamentoContext.Domain.Commands
{
    public class CreateAssinaturaBoletoCommand : ICommand
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public string CodigoBarra { get; set; }
        public string NossoNumero { get; set; }

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

    }
}
