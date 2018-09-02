using System;

namespace PagamentoContext.Domain.Entities
{
    public class PayPalPagamento : Pagamento
    {
        public PayPalPagamento(string codigoTransacao, DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago, string pagador, string documento, string endereco, string email) : base(dataPagamento, dataExpiracao, total, totalPago, pagador, documento, endereco, email)
        {
            CodigoTransacao = codigoTransacao;
        }

        public string CodigoTransacao { get; private set; }
    }
}
