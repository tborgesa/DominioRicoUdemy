using PagamentoContext.Domain.ValueObjects;
using System;

namespace PagamentoContext.Domain.Entities
{
    public class BoletoPagamento : Pagamento
    {
        public BoletoPagamento(string codigoBarra, string nossoNumero, DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago,
            string pagador, Documento documento, Endereco endereco, Email email) : base(dataPagamento, dataExpiracao, total, totalPago, pagador, documento, endereco, email)
        {
            CodigoBarra = codigoBarra;
            NossoNumero = nossoNumero;
        }

        public string CodigoBarra { get; private set; }
        public string NossoNumero { get; private set; }
    }
}
