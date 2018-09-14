using PagamentoContext.Domain.ValueObjects;
using System;

namespace PagamentoContext.Domain.Entities
{
    public class CartaoCreditoPagamento : Pagamento
    {
        public CartaoCreditoPagamento(string nomeTitular, string numero, string numeroUltimaTransacao, DateTime dataPagamento, DateTime dataExpiracao,
            decimal total, decimal totalPago, string pagador, Documento documento, Endereco endereco, Email email) : base(dataPagamento, dataExpiracao, total, totalPago, pagador, documento, endereco, email)
        {
            NomeTitular = nomeTitular;
            NumeroTransacao = numero;
            NumeroUltimaTransacao = numeroUltimaTransacao;
        }

        public string NomeTitular { get; private set; }
        public string NumeroTransacao { get; private set; }
        public string NumeroUltimaTransacao { get; private set; }
    }
}
